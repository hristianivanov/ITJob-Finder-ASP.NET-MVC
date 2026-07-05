namespace DevHunter.Services.Data
{
    using System.Linq.Expressions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using DevHunter.Data;
    using DevHunter.Data.Models;

    using Interfaces;
    using Web.ViewModels.Technology;
    using Web.Infrastructure.Extensions;

    public class TechnologyService : ITechnologyService
    {
        private readonly DevHunterDbContext dbContext;

        private readonly IImageService imageService;

        public TechnologyService(DevHunterDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public async Task<bool> TechnologyExistsByNameAsync(string technologyName)
        {
            bool exists = await this.dbContext
                .Technologies
                .AnyAsync(t => t.Name.ToLower() == technologyName.ToLower());

            return exists;
        }

        public async Task AddAsync(TechnologyFormModel formModel, Guid? developmentId)
        {
            Technology technology = new Technology()
            {
                Name = formModel.Name,
                ImageUrl = await this.imageService
                    .UploadImage(formModel.Image, "DevHunter/technology", formModel.Name)
            };

            if (developmentId.HasValue)
            {
                var development = await this.dbContext.Developments
                    .FirstOrDefaultAsync(d => d.Id == developmentId.Value);

                if (development != null)
                {
                    TechnologyDevelopments technologyDevelopments = new TechnologyDevelopments()
                    {
                        DevelopmentId = development!.Id,
                        TechnologyId = technology.Id,
                        IsActive = true,
                    };

                    await this.dbContext.TechnologiesDevelopments.AddAsync(technologyDevelopments);
                }
            }

            await this.dbContext.Technologies.AddAsync(technology);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TechnologyViewModel>> AllAsync()
        {
            var technologies = await this.dbContext
                .Technologies
                .AsNoTracking()
                .Select(ToEnhancedViewModel)
                .ToListAsync();

            return technologies;
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.dbContext.Technologies.AnyAsync(t => t.Id == id);

        public async Task<TechnologyEditFormModel> GetForEditByIdAsync(Guid id)
        {
            var technology = await this.dbContext
                .Technologies
                .FirstAsync(t => t.Id == id);

            return new TechnologyEditFormModel
            {
                Name = technology.Name,
                ImageUrl = technology.ImageUrl,
            };
        }

        public async Task EditTechnologyAsync(Guid technologyId, TechnologyEditFormModel model)
        {
            var technology = await this.dbContext
                .Technologies
                .FirstAsync(t => t.Id == technologyId);

            bool isChanged = false;

            if (technology.Name != model.Name)
            {
                technology.Name = model.Name;
                isChanged = true;
            }

            if (model.Image != null)
            {
                technology.ImageUrl =
                    await this.imageService.EditImage(model.Image, technology.ImageUrl, technology.Name, "DevHunter/technology");
                isChanged = true;
            }

            if (isChanged)
            {
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var technology = await this.dbContext
                .Technologies
                .FirstOrDefaultAsync(t => t.Id == id);

            if (technology != null)
            {
                this.dbContext.Technologies.Remove(technology);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TechnologyViewModel>> AllByDevelopmentAsync(Guid id)
        {
            var technologies = await this.dbContext
                .TechnologiesDevelopments
                .AsNoTracking()
                .Where(t => t.DevelopmentId == id)
                .Select(t => t.Technology)
                .Select(ToEnhancedViewModel)
                .ToListAsync();

            if (technologies.Count == 0)
                return technologies;

            var techIds = technologies
                .Select(t => Guid.Parse(t.Id))
                .ToList();

            var counts = await this.dbContext.TechnologyJobOffers
                .Where(t => techIds.Contains(t.TechnologyId))
                .GroupBy(t => t.TechnologyId)
                .Select(g => new { TechnologyId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.TechnologyId, x => x.Count);

            foreach (var technology in technologies)
            {
                if (Guid.TryParse(technology.Id, out var techId))
                    technology.Count = counts.GetValueOrDefault(techId, 0);
            }

            return technologies;
        }

        public async Task<IEnumerable<TechnologyViewModel>> AllByJobOfferIdAsync(Guid id)
        {
            var technologies = await this.dbContext
                .TechnologyJobOffers
                .Where(tj => tj.JobOfferId == id)
                .Select(tj => new TechnologyViewModel()
                {
                    Id = tj.TechnologyId.ToString(),
                    Name = tj.Technology.Name,
                    ImageUrl = tj.Technology.ImageUrl
                })
                .ToListAsync();

            return technologies;
        }

        public async Task<IEnumerable<TechnologyViewModel>> AllWithoutJobOfferOnesAsync(Guid id)
        {
            var jobOffer = await this.dbContext
                .JobOffers
                .Include(j => j.JobOfferTechnologies)
                .FirstAsync(j => j.Id == id);

            var existingTechnologyIds = jobOffer.JobOfferTechnologies.Select(t => t.TechnologyId).ToList();

            var technologies = await this.dbContext
                .Technologies
                .Where(t => !existingTechnologyIds.Any(et => t.Id == et))
                .AsNoTracking()
                .Select(ToEnhancedViewModel)
                .ToListAsync();

            return technologies;
        }

        private static readonly Expression<Func<Technology, TechnologyViewModel>> ToEnhancedViewModel =
            technology => new TechnologyViewModel
            {
                Id = technology.Id.ToString(),
                Name = technology.Name,
                ImageUrl = technology.ImageUrl.EnhanceCloudinaryUrl(50, "auto")
            };

    }
}
