using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using DevHunter.Web.ViewModels.Technology;

namespace DevHunter.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using DevHunter.Data.Models;
	using Interfaces;
	using Models.JobOffer;
	using Web.ViewModels.JobOffer;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using static DevHunter.Common.EntityValidationConstants;

	public class JobOfferService : IJobOfferService
	{
		private readonly DevHunterDbContext dbContext;

		public JobOfferService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel)
		{
			IQueryable<DevHunter.Data.Models.JobOffer> jobOffersQuery = this.dbContext
				.JobOffers
				//.Where(j => j.IsActive)
				.AsQueryable();


			IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
				//.Where(j => j.IsActive) TODO: is it necessary?
				.Include(j => j.JobOfferTechnologies)
				.ThenInclude(jt => jt.Technology)
				.Include(j => j.Company)
				.Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
				.Take(queryModel.JobOffersPerPage)
				.Select(j => new JobOfferAllViewModel
				{
					Id = j.Id.ToString(),
					JobPosition = j.JobPosition,
					CompanyImageUrl = j.Company.ImageUrl!,
					CompanyName = j.Company.Name,
					CreatedOn = j.CreatedOn.ToString("dd MMM."),
					JobLocation = j.PlaceToWork,
					Technologies = j.JobOfferTechnologies
						.Select(tj => new TechnologyViewModel()
						{
							Id = tj.Technology.Id.ToString(),
							Name = tj.Technology.Name,
							ImageUrl = tj.Technology.ImageUrl,
						}).ToList(),
					Salary = GetSalary(j.MinSalary!.Value, j.MaxSalary!.Value),
				})
				.ToArrayAsync();

			int totalJobOffers = jobOffersQuery.Count();

			return new AllJobOffersFilteredAndPagedServiceModel()
			{
				TotalJobOffersCount = totalJobOffers,
				JobOffers = allJobOffers
			};
		}

		public async Task AddAsync(JobOfferFormModel model, string userId)
		{
			var company = await this.dbContext
				.Companies
				.FirstOrDefaultAsync(c => c.CreatorId.ToString() == userId);

			if (company != null)
			{
				var jobOffer = new DevHunter.Data.Models.JobOffer()
				{
					JobPosition = model.Title,
					Description = model.Description,
					WorkingHours = model.WorkingHours!.Value,
					CreatedOn = DateTime.UtcNow,
					PlaceToWork = model.IsRemote && string.IsNullOrWhiteSpace(model.Location) ? "Remote" : model.Location!,
					MaxSalary = model.Salary!.Value,
					CompanyId = company.Id,
				};

				string[] techStackNames = JsonConvert.DeserializeObject<string[]>(model.SelectedTechnologies)!;
				var techStack = new List<DevHunter.Data.Models.Technology>();

				foreach (var techName in techStackNames)
				{
					var tech = await this.dbContext.Technologies.FirstOrDefaultAsync(t => t.Name == techName);

					if (tech != null)
					{
						techStack.Add(tech);
					}
				}

				foreach (var tech in techStack)
				{
					var jobOfferTechnology = new TechnologyJobOffers()
					{
						JobOfferId = jobOffer.Id,
						TechnologyId = tech.Id,
					};

					await this.dbContext.TechnologyJobOffers.AddAsync(jobOfferTechnology);
				}

				await this.dbContext.JobOffers.AddAsync(jobOffer);
				await this.dbContext.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsByIdAsync(string id)
		{
			var result = await this.dbContext
				.JobOffers
				.FirstOrDefaultAsync(j => j.Id.ToString() == id);

			return result != null;
		}

		public async Task<JobOfferDetailsViewModel> GetDetailsByIdAsync(string id)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.Include(j => j.JobOfferTechnologies)
				.ThenInclude(jt => jt.Technology)
				.Include(j => j.Company)
				.FirstOrDefaultAsync(j => j.Id.ToString() == id);

			var techStack = jobOffer!
				.JobOfferTechnologies
				.Select(tj => new TechnologyViewModel()
				{
					Id = tj.Technology.Id.ToString(),
					Name = tj.Technology.Name,
					ImageUrl = tj.Technology.ImageUrl,
				}).ToList();

			return new JobOfferDetailsViewModel()
			{
				Id = jobOffer!.Id.ToString(),
				Title = jobOffer.JobPosition,
				Description = jobOffer.Description,
				JobLocation = jobOffer.PlaceToWork,
				CreatedOn = jobOffer.CreatedOn.ToString("dd MMM."),
				Company = new Web.ViewModels.Company.CompanyViewModel()
				{
					Id = jobOffer.Company.Id.ToString(),
					Name = jobOffer.Company.Name,
					ImageUrl = jobOffer.Company.ImageUrl!,
				},
				TechStack = techStack,
			};
		}

		public async Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyIdAsync(string userId)
		{
			var company = await this.dbContext
				.Companies
				//.Include(c => c.JobOffers)
				//.ThenInclude(j => j.JobOfferTechnologies)
				//.ThenInclude(j => j.Technology)
				.FirstAsync(c => c.CreatorId.ToString() == userId);

			var jobOffers = company.JobOffers.Select(j => new JobOfferAllViewModel()
			{
				Id = j.Id.ToString(),
				CompanyName = company.Name,
				CompanyImageUrl = company.ImageUrl!,
				CreatedOn = j.CreatedOn.ToString("dd.MM.yyyy"),
				JobLocation = j.PlaceToWork,
				JobPosition = j.JobPosition,
				Salary = GetSalary(j.MinSalary, j.MaxSalary),
				Technologies = j.JobOfferTechnologies.Select(tj => new TechnologyViewModel()
				{
					Id = tj.TechnologyId.ToString(),
					ImageUrl = tj.Technology.ImageUrl!,
					Name = tj.Technology.Name,
				}),
			})
				.ToList();

			return jobOffers;
		}

		public async Task<JobOfferEditFormModel> GetForEditByIdAsync(string id)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.Include(j => j.JobOfferTechnologies)
				.ThenInclude(j => j.Technology)
				.FirstAsync(j => j.Id.ToString() == id);

			var jobOfferTechnologies = jobOffer.JobOfferTechnologies
				.Select(tj => new TechnologyViewModel()
				{
					Id = tj.Technology.Id.ToString(),
					Name = tj.Technology.Name,
					ImageUrl = tj.Technology.ImageUrl!,
				}).ToList();

			return new JobOfferEditFormModel()
			{
				Title = jobOffer.JobPosition,
				Description = jobOffer.Description,
				Location = jobOffer.PlaceToWork,
				Salary = jobOffer.MaxSalary,
				WorkingHours = jobOffer.WorkingHours,
				WorkingExperience = jobOffer.WorkingExperience,
				JobOfferTechnologies = jobOfferTechnologies
			};
		}

		public async Task DeleteByIdAsync(string id)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.FirstOrDefaultAsync(t => t.Id.ToString() == id);

			if (jobOffer != null)
			{
				this.dbContext.JobOffers.Remove(jobOffer);
				await this.dbContext.SaveChangesAsync();
			}
		}

		public async Task<AllFilterViewModel> LoadFiltersAsync()
		{
			var locations = await this.dbContext
				.JobOffers
				.Select(j => j.PlaceToWork)
				.Distinct()
				.Select(place => new LocationFilter
				{
					Location = place,
				})
				.ToListAsync();

			foreach (var location in locations)
			{
				location.Count = await this.dbContext
					.JobOffers
					.CountAsync(j => j.PlaceToWork == location.Location);
			}

			var experiences = await this.dbContext
				.JobOffers
				.Where(j => !string.IsNullOrWhiteSpace(j.WorkingExperience))
				.Select(j => j.WorkingExperience)
				.Distinct()
				.Select(experience => new SeniorityFilter
				{
					Seniority = experience!
				})
				.ToListAsync();

			//TODO: order	

			foreach (var filter in experiences)
			{
				filter.Count = await this.dbContext
					.JobOffers
					.CountAsync(j => j.WorkingExperience == filter.Seniority);
			}

			return new AllFilterViewModel()
			{
				FilterLocations = locations,
				FilterExperiences = experiences
			};
		}

		public async Task<string> CreateAndReturnIdAsync(JobOfferFormModel model, string userId)
		{
			var company = await this.dbContext
			.Companies
				.FirstOrDefaultAsync(c => c.CreatorId.ToString() == userId);

			var jobOffer = new DevHunter.Data.Models.JobOffer()
			{
				JobPosition = model.Title,
				Description = model.Description,
				WorkingHours = model.WorkingHours!.Value,
				CreatedOn = DateTime.UtcNow,
				PlaceToWork = model.IsRemote && string.IsNullOrWhiteSpace(model.Location) ? "Remote" :
					model.IsRemote ? $"{model.Location} Hybrid" : model.Location!,
				MaxSalary = model.Salary!.Value,
				WorkingExperience = model.WorkingExperience,
				CompanyId = company.Id,
			};

			string[] techStackNames = JsonConvert.DeserializeObject<string[]>(model.SelectedTechnologies)!;
			var techStack = new List<DevHunter.Data.Models.Technology>();

			foreach (var techName in techStackNames)
			{
				var tech = await this.dbContext.Technologies.FirstOrDefaultAsync(t => t.Name == techName);

				if (tech != null)
				{
					techStack.Add(tech);
				}
			}

			foreach (var tech in techStack)
			{
				var jobOfferTechnology = new TechnologyJobOffers()
				{
					JobOfferId = jobOffer.Id,
					TechnologyId = tech.Id,
				};

				await this.dbContext.TechnologyJobOffers.AddAsync(jobOfferTechnology);
			}

			await this.dbContext.JobOffers.AddAsync(jobOffer);
			await this.dbContext.SaveChangesAsync();


			return jobOffer.Id!.ToString();
		}

		private static string GetSalary(decimal? minSalary, decimal? maxSalary)
		{
			string? formattedMaxSalary = maxSalary?
				.ToString("#,0", CultureInfo.InvariantCulture)
				.Replace(",", " ");
			string? formattedMinSalary = minSalary?
				.ToString("#,0", CultureInfo.InvariantCulture)
				.Replace(",", " ");

			if (!string.IsNullOrWhiteSpace(formattedMinSalary))
			{
				return $"{formattedMinSalary} - {formattedMaxSalary} lv.";
			}

			return $"{formattedMaxSalary} lv.";
		}

	}
}