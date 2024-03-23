namespace DevHunter.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using DevHunter.Data.Models;

	using Interfaces;
	using Web.ViewModels.Technology;
	using Web.Infrastructure.Extensions;

	using static Common.EntityValidationConstants.Technology;
	using Microsoft.AspNetCore.Http.Internal;
	using Microsoft.AspNetCore.Http;

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

		public async Task AddAsync(TechnologyFormModel formModel,string developmentId)
		{
			Technology technology = new Technology()
			{
				Name = formModel.Name,
				ImageUrl = await this.imageService
					.UploadImage(formModel.Image, "DevHunter/technology", formModel.Name)
			};

			if (!string.IsNullOrWhiteSpace(developmentId))
			{
				var development = await this.dbContext.Developments
					.FirstOrDefaultAsync(d => d.Id.ToString() == developmentId);

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
				.Select(t => new TechnologyViewModel()
				{
					Id = t.Id.ToString(),
					Name = t.Name,
					ImageUrl = t.ImageUrl.EnhanceCloudinaryUrl(50, "auto")
				})
				.ToListAsync();

			return technologies;
		}

		public async Task<bool> ExistsByIdAsync(string id)
		{
			bool result = await this.dbContext
				.Technologies
				.AnyAsync(t => t.Id.ToString() == id);

			return result;
		}

		public async Task<TechnologyEditFormModel> GetForEditByIdAsync(string id)
		{
			var technology = await this.dbContext
				.Technologies
				.FirstAsync(t => t.Id.ToString() == id);

			return new TechnologyEditFormModel
			{
				Name = technology.Name,
				ImageUrl = technology.ImageUrl,
			};
		}

		public async Task EditTechnologyAsync(string technologyId, TechnologyEditFormModel model)
		{
			var technology = await this.dbContext
				.Technologies
				.FirstAsync(t => t.Id.ToString() == technologyId);

			bool isChanged = false;

			if (technology.Name != model.Name)
			{
				technology.Name = model.Name;
				isChanged = true;
			}

			if (model.Image != null)
			{
				technology.ImageUrl = await this.imageService.EditImage(model.Image, technology.ImageUrl, technology.Name, "DevHunter/technology");
				isChanged = true;
			}

			if (isChanged)
			{
				await this.dbContext.SaveChangesAsync();
			}
		}

		public async Task DeleteByIdAsync(string id)
		{
			var technology = await this.dbContext
				.Technologies
				.FirstOrDefaultAsync(t => t.Id.ToString() == id);

			if (technology != null)
			{
				this.dbContext.Technologies.Remove(technology);
				await this.dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<TechnologyViewModel>> AllByDevelopmentAsync(string id)
		{
			var technologies = await this.dbContext
				.TechnologiesDevelopments
				.AsNoTracking()
				.Where(t => t.DevelopmentId.ToString() == id)
				.Select(t => new TechnologyViewModel()
				{
					Id = t.Technology.Id.ToString(),
					Name = t.Technology.Name,
					ImageUrl = t.Technology.ImageUrl.EnhanceCloudinaryUrl(50, "auto")
				})
				.ToListAsync();

			return technologies;
		}

		public async Task<IEnumerable<TechnologyViewModel>> AllByJobOfferIdAsync(string id)
		{
			var technologies = await this.dbContext
				.TechnologyJobOffers
				.Where(tj => tj.JobOfferId.ToString() == id)
				.Select(tj => new TechnologyViewModel()
				{
					Id = tj.TechnologyId.ToString(),
					Name = tj.Technology.Name,
					ImageUrl = tj.Technology.ImageUrl
				})
				.ToListAsync();

			return technologies;
		}

		public async Task<IEnumerable<TechnologyViewModel>> AllWithoutJobOfferOnesAsync(string id)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.FirstAsync(j => j.Id.ToString() == id);

			var existingTechnologyIds = jobOffer.JobOfferTechnologies.Select(t => t.TechnologyId).ToList();

			var technologies = await this.dbContext
				.Technologies
				.Where(t => !existingTechnologyIds.Any(et => t.Id == et))
				.AsNoTracking()
				.Select(t => new TechnologyViewModel()
				{
					Id = t.Id.ToString(),
					Name = t.Name,
					ImageUrl = t.ImageUrl.EnhanceCloudinaryUrl(50, "auto")
				})
				.ToListAsync();

			return technologies;
		}

		private async Task<IFormFile> ConvertImageUrlToFormFileAsync(string imageUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

				string fileName = Path.GetFileName(imageUrl);

				using (MemoryStream stream = new MemoryStream(imageBytes))
				{
					IFormFile formFile = new FormFile(stream, 0, imageBytes.Length, "file", fileName);

					return formFile;
				}
			}
		}
	}
}
