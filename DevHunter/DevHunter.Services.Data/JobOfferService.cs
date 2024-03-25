namespace DevHunter.Services.Data
{
	using System.Globalization;

	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using Ganss.Xss;

	using DevHunter.Data;
	using DevHunter.Data.Models;
	using DevHunter.Data.Models.Enums;
	using Models.JobOffer;
	using Interfaces;
	using Web.ViewModels.JobOffer;
	using Web.ViewModels.Technology;

	public class JobOfferService : IJobOfferService
	{
		private readonly DevHunterDbContext dbContext;

		public JobOfferService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel)
		{
			IQueryable<JobOffer> jobOffersQuery = this.dbContext
				.JobOffers
				//.Where(j => j.IsActive)
				.AsQueryable();

			if (!string.IsNullOrWhiteSpace(queryModel.JobLocation))
			{
				var locationSet = new HashSet<string>(queryModel.JobLocation.Split(','));

				jobOffersQuery = jobOffersQuery
					.Where(j => locationSet.Any(location => location == j.PlaceToWork));

				foreach (var filter in queryModel.Filters.Locations)
				{
					if (locationSet.Contains(filter.Location))
						filter.IsChecked = true;
				}
			}

			if (!string.IsNullOrWhiteSpace(queryModel.Experience))
			{
				var experienceSet = new HashSet<string>(queryModel.Experience.Split(","));

				jobOffersQuery = jobOffersQuery
					.Where(j => experienceSet.Any(experience => experience == j.WorkingExperience));

				foreach (var filter in queryModel.Filters.Experiences)
				{
					if (experienceSet.Contains(filter.Seniority))
						filter.IsChecked = true;
				}
			}

			if (queryModel.FilterType != "location")
			{
				foreach (var location in queryModel.Filters.Locations)
				{
					location.Count = await jobOffersQuery
						.CountAsync(j => j.PlaceToWork == location.Location);
				}
			}
			else
			{
				foreach (var location in queryModel.Filters.Locations)
				{
					location.Count = await this.dbContext
						.JobOffers
						.CountAsync(j => j.PlaceToWork == location.Location);
				}
			}

			if (queryModel.FilterType != "experience")
			{
				foreach (var filter in queryModel.Filters.Experiences)
				{
					filter.Count = await jobOffersQuery
						.CountAsync(j => j.WorkingExperience == filter.Seniority);
				}
			}
			else
			{
				foreach (var filter in queryModel.Filters.Experiences)
				{
					filter.Count = await this
						.dbContext
						.JobOffers
						.CountAsync(j => j.WorkingExperience == filter.Seniority);
				}
			}

			queryModel.Filters.Locations = queryModel.Filters.Locations.OrderByDescending(l => l.Count).ToList();
			queryModel.Filters.Experiences = queryModel.Filters.Experiences.OrderByDescending(l => l.Count).ToList();

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
					PlaceToWorkType = j.JobPlace.ToString(),
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

		private async Task<AllFilterViewModel> LoadFiltersAsync(IQueryable<JobOffer> jobOffersQuery)
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
				location.Count = await jobOffersQuery
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

			var juniorExperience = experiences.First(e => e.Seniority == "Junior");
			experiences.Remove(juniorExperience);
			experiences.Insert(0, juniorExperience);

			foreach (var filter in experiences)
			{
				filter.Count = await jobOffersQuery
					.CountAsync(j => j.WorkingExperience == filter.Seniority);
			}

			return new AllFilterViewModel()
			{
				Locations = locations,
				Experiences = experiences
			};
		}

		public async Task<IEnumerable<JobOfferAllViewModel>> FilterAllAsync(JofOfferFilterFormData filters)
		{
			IQueryable<DevHunter.Data.Models.JobOffer> jobOffersQuery = this.dbContext
				.JobOffers
				//.Where(j => j.IsActive)
				.AsQueryable();

			if (filters.Locations.Any())
			{
				jobOffersQuery = jobOffersQuery
					.Where(j => filters.Locations.Any(location => location == j.PlaceToWork));
			}

			if (filters.Experiences.Any())
			{
				jobOffersQuery = jobOffersQuery
					.Where(j => filters.Experiences.Any(experience => experience == j.WorkingExperience));
			}

			IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
				//.Where(j => j.IsActive) TODO: is it necessary?
				.Select(j => new JobOfferAllViewModel
				{
					Id = j.Id.ToString(),
					JobPosition = j.JobPosition,
					CompanyImageUrl = j.Company.ImageUrl!,
					CompanyName = j.Company.Name,
					CreatedOn = j.CreatedOn.ToString("dd MMM."),
					PlaceToWorkType = j.JobPlace.ToString(),
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

			return allJobOffers;
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
					//PlaceToWork = model.IsRemote && string.IsNullOrWhiteSpace(model.Location) ? "Remote" : model.Location!,
					MaxSalary = model.Salary!.Value,
					CompanyId = company.Id,
				};

				string[] techStackNames = JsonConvert.DeserializeObject<string[]>(model.Technologies)!;
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

			return new JobOfferEditFormModel()
			{
				Title = jobOffer.JobPosition,
				Description = jobOffer.Description,
				Location = jobOffer.PlaceToWork,
				Salary = jobOffer.MaxSalary,
				LocationType = jobOffer.JobPlace,
				WorkingHours = jobOffer.WorkingHours,
				WorkingExperience = jobOffer.WorkingExperience,
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

			return new AllFilterViewModel()
			{
				Locations = locations,
				Experiences = experiences
			};
		}

		public async Task EditJobOfferAsync(string id, JobOfferEditFormModel model)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.FirstAsync(j => j.Id.ToString() == id);

			bool isChanged = false;

			if (model.Title != jobOffer.JobPosition)
			{
				jobOffer.JobPosition = model.Title;
				isChanged = true;
			}

			if (model.Location != jobOffer.PlaceToWork)
			{
				jobOffer.PlaceToWork = model.Location!;
				isChanged = true;
			}

			if (model.LocationType!.Value != jobOffer.JobPlace)
			{
				jobOffer.JobPlace = model.LocationType.Value;

				if (jobOffer.JobPlace == PlaceToWork.Remote)
				{
					jobOffer.PlaceToWork = "Remote";
				}

				isChanged = true;
			}


			if (model.WorkingExperience != jobOffer.WorkingExperience)
			{
				jobOffer.WorkingExperience = model.WorkingExperience;
				isChanged = true;
			}

			if (model.Salary != jobOffer.MaxSalary &&
				model.Salary.HasValue)
			{
				jobOffer.MaxSalary = model.Salary;
				isChanged = true;
			}

			if (model.WorkingHours != jobOffer.WorkingHours &&
				model.WorkingHours.HasValue)
			{
				jobOffer.WorkingHours = model.WorkingHours.Value;
				isChanged = true;
			}

			if (model.Description != jobOffer.Description)
			{
				var sanitizer = new HtmlSanitizer();

				var sanitized = sanitizer.Sanitize(model.Description);

				jobOffer.Description = sanitized;

				isChanged = true;
			}

			if (model.Technologies != "[]")
			{
				string[] techStackNames = JsonConvert.DeserializeObject<string[]>(model.Technologies!)!;

				var techStack = await dbContext.Technologies
					.Where(t => techStackNames.Contains(t.Name))
					.ToListAsync();

				var existingTechnologyIds = await dbContext.TechnologyJobOffers
					.Where(t => t.JobOfferId == jobOffer.Id)
					.Select(t => t.TechnologyId)
					.ToListAsync();

				var jobOfferTechnologies = techStack
					.Where(tech => !existingTechnologyIds.Contains(tech.Id))
					.Select(tech => new TechnologyJobOffers
					{
						JobOfferId = jobOffer.Id,
						TechnologyId = tech.Id
					})
					.ToList();

				isChanged = true;

				await dbContext.TechnologyJobOffers.AddRangeAsync(jobOfferTechnologies);
			}

			if (isChanged)
			{
				await this.dbContext.SaveChangesAsync();
			}
		}



		public async Task<string> CreateAndReturnIdAsync(JobOfferFormModel model, string userId)
		{
			var company = await this.dbContext
			.Companies
				.FirstAsync(c => c.CreatorId.ToString() == userId);

			var sanitizer = new HtmlSanitizer();

			var jobOffer = new DevHunter.Data.Models.JobOffer()
			{
				JobPosition = model.Title,
				Description = sanitizer.Sanitize(model.Description),
				CreatedOn = DateTime.UtcNow,
				JobPlace = model.LocationType!.Value,
				PlaceToWork = model.LocationType.Value == PlaceToWork.Remote ? "Remote" : model.Location!,
				WorkingExperience = model.WorkingExperience,
				CompanyId = company.Id,
			};

			if (model.WorkingHours.HasValue)
			{
				jobOffer.WorkingHours = model.WorkingHours!.Value;
			}

			if (model.Salary.HasValue)
			{
				jobOffer.MaxSalary = model.Salary!.Value;
			}

			if (model.Technologies != "[]")
			{
				string[] techStackNames = JsonConvert.DeserializeObject<string[]>(model.Technologies)!;

				var techStack = await dbContext.Technologies
					.Where(t => techStackNames.Contains(t.Name))
					.ToListAsync();

				var jobOfferTechnologies = techStack
					.Select(tech => new TechnologyJobOffers
					{
						JobOfferId = jobOffer.Id,
						TechnologyId = tech.Id
					})
					.ToList();

				await dbContext.TechnologyJobOffers.AddRangeAsync(jobOfferTechnologies);
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
		private static bool IsValidEnumValue<TEnum>(TEnum value)
		{
			return Enum.IsDefined(typeof(TEnum), value);
		}
	}
}