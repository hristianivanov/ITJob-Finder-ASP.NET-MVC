namespace DevHunter.Services.Data
{
    using Mapster;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    using DevHunter.Data;

    using Interfaces;
    using Web.ViewModels.Development;
    using Web.ViewModels.Technology;

    using Development = DevHunter.Data.Models.Development;

    public class DevelopmentService : IDevelopmentService
    {
        private const string AllDevelopmentsCacheKey = "all_developments";
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);

        private readonly IImageService imageService;
        private readonly ITechnologyService technologyService;
        private readonly DevHunterDbContext dbContext;
        private readonly IMemoryCache cache;

        public DevelopmentService(DevHunterDbContext dbContext, IImageService imageService, ITechnologyService technologyService, IMemoryCache cache)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
            this.technologyService = technologyService;
            this.cache = cache;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool exists = await this.dbContext
                .Developments
                .AnyAsync(t => t.Name.ToLower() == name.ToLower());

            return exists;
        }

        public async Task AddAsync(DevelopmentFormModel formModel)
        {
            Development development = new Development()
            {
                Name = formModel.Name,
                ImageUrl = await this.imageService
                    .UploadImage(formModel.Image, "DevHunter/development", formModel.Name)
            };

            await this.dbContext.Developments.AddAsync(development);
            await this.dbContext.SaveChangesAsync();

            this.cache.Remove(AllDevelopmentsCacheKey);
        }

        public async Task<List<DevelopmentViewModel>> AllAsync()
        {
            if (this.cache.TryGetValue(AllDevelopmentsCacheKey, out List<DevelopmentViewModel>? cached))
                return cached!;

            var developments = await this.dbContext
                .Developments
                .OrderBy(d => d.SortOrder)
                .Select(d => new DevelopmentViewModel()
                {
                    Id = d.Id.ToString(),
                    Name = d.Name,
                    ImageUrl = d.ImageUrl
                })
                .ToListAsync();

            var developmentIds = developments
                .Select(d => Guid.Parse(d.Id))
                .ToList();

            var allTechCounts = await this.dbContext.TechnologyJobOffers
                .GroupBy(t => t.TechnologyId)
                .Select(g => new { TechnologyId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.TechnologyId, x => x.Count);

            var allTechsByDev = await this.dbContext.TechnologiesDevelopments
                .AsNoTracking()
                .Where(td => developmentIds.Contains(td.DevelopmentId))
                .Select(td => new
                {
                    td.DevelopmentId,
                    TechId = td.TechnologyId,
                    td.Technology.Name,
                    td.Technology.ImageUrl
                })
                .ToListAsync();

            foreach (var development in developments)
            {
                var devId = Guid.Parse(development.Id);
                var techs = allTechsByDev
                    .Where(t => t.DevelopmentId == devId)
                    .Select(t => new Web.ViewModels.Technology.TechnologyViewModel
                    {
                        Id = t.TechId.ToString(),
                        Name = t.Name,
                        ImageUrl = t.ImageUrl,
                        Count = allTechCounts.GetValueOrDefault(t.TechId, 0)
                    })
                    .Where(t => t.Count > 0)
                    .ToList();

                development.Technologies = techs;
                development.Count = techs.Sum(t => t.Count);
            }

            this.cache.Set(AllDevelopmentsCacheKey, developments, CacheDuration);

            return developments;
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.dbContext.Developments.AnyAsync(t => t.Id == id);

        public async Task<DevelopmentEditFormModel> GetForEditByIdAsync(Guid id)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(t => t.Id == id);

            return development.Adapt<DevelopmentEditFormModel>();
        }

        public async Task EditDevelopmentAsync(Guid id, DevelopmentEditFormModel model)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(t => t.Id == id);

            bool isChanged = false;

            if (development.Name != model.Name)
            {
                development.Name = model.Name;
                isChanged = true;
            }

            if (model.Image != null)
            {
                development.ImageUrl =
                    await this.imageService.EditImage(model.Image, development.ImageUrl, development.Name, "DevHunter/development");
                isChanged = true;
            }

            if (isChanged)
            {
                await this.dbContext.SaveChangesAsync();
                this.cache.Remove(AllDevelopmentsCacheKey);
            }
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var development = await this.dbContext
                .Developments
                .Include(d => d.DevelopmentTechnologies)
                .FirstAsync(d => d.Id == id);

            if (development.DevelopmentTechnologies.Any())
            {
                foreach (var item in development.DevelopmentTechnologies)
                {
                    item.IsActive = false;
                }
            }

            this.dbContext.Developments.Remove(development);
            await this.dbContext.SaveChangesAsync();
            this.cache.Remove(AllDevelopmentsCacheKey);
        }

        public async Task<DevelopmentOfferViewModel> GetByIdAsync(Guid id)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(d => d.Id == id);

            return development.Adapt<DevelopmentOfferViewModel>();
        }
    }
}
