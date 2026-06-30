namespace DevHunter.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using DevHunter.Data;

    using Interfaces;
    using Web.ViewModels.Development;
    using Web.ViewModels.Technology;

    using Development = DevHunter.Data.Models.Development;

    public class DevelopmentService : IDevelopmentService
    {
        private readonly IImageService imageService;
        private readonly ITechnologyService technologyService;
        private readonly DevHunterDbContext dbContext;

        public DevelopmentService(DevHunterDbContext dbContext, IImageService imageService, ITechnologyService technologyService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
            this.technologyService = technologyService;
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
        }

        public async Task<List<DevelopmentViewModel>> AllAsync()
        {
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

            return developments;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.dbContext
                .Developments
                .AnyAsync(t => t.Id.ToString() == id);

            return result;
        }

        public async Task<DevelopmentEditFormModel> GetForEditByIdAsync(string id)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(t => t.Id.ToString() == id);

            return new DevelopmentEditFormModel
            {
                Name = development.Name,
                ImageUrl = development.ImageUrl,
            };
        }

        public async Task EditDevelopmentAsync(string id, DevelopmentEditFormModel model)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(t => t.Id.ToString() == id);

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
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            var development = await this.dbContext
                .Developments
                .Include(d => d.DevelopmentTechnologies)
                .FirstAsync(d => d.Id.ToString() == id);

            if (development.DevelopmentTechnologies.Any())
            {
                foreach (var item in development.DevelopmentTechnologies)
                {
                    item.IsActive = false;
                }
            }

            this.dbContext.Developments.Remove(development);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<DevelopmentOfferViewModel> GetByIdAsync(string id)
        {
            var development = await this.dbContext
                .Developments
                .FirstAsync(d => d.Id.ToString() == id);

            return new DevelopmentOfferViewModel()
            {
                Name = development.Name,
                ImageUrl = development.ImageUrl
            };
        }
    }
}
