namespace DevHunter.Services.Data
{
	using System.Globalization;
	using System.Text.RegularExpressions;

	using Ganss.Xss;
	using Newtonsoft.Json;
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using DevHunter.Data.Models;
	using DevHunter.Data.Models.Enums;

	using Models.JobOffer;
	using Interfaces;
	using Web.ViewModels.JobOffer;
	using Web.ViewModels.Technology;

	using static Common.GeneralApplicationConstants.JobOffer;

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

			jobOffersQuery = FilterJobOffers(queryModel, jobOffersQuery);

			if (jobOffersQuery.Any(j => j.MaxSalary.HasValue))
			{
				queryModel.Filters.IsSalaryAvailable = true;
			}

			await CountFilters(queryModel, jobOffersQuery);

			OrderFilters(queryModel);

			IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
				.Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
				.Take(queryModel.JobOffersPerPage)
				.Select(j => new JobOfferAllViewModel
				{
					Id = j.Id.ToString(),
					JobPosition = j.JobPosition,
					CompanyImageUrl = j.Company.ImageUrl!,
					CompanyName = j.Company.Name,
					CreatedOn = j.CreatedOn.ToString(CreatedOnDateFormat, CultureInfo.InvariantCulture),
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

		public async Task<AllJobOffersFilteredAndPagedServiceModel> AllBySearchAsync(AllJobOffersQueryModel queryModel)
		{
			IQueryable<JobOffer> jobOffersQuery = this.dbContext
				.JobOffers
				//.Where(j => j.IsActive)
				.AsQueryable();

			if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
			{
				string wildCard = $"%{queryModel.SearchString.ToLower()}%";

				jobOffersQuery = jobOffersQuery
					.Where(j => EF.Functions.Like(j.JobPosition, wildCard) ||
								EF.Functions.Like(j.Company.Name, wildCard) ||
								EF.Functions.Like(j.PlaceToWork, wildCard));
			}

			IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
				.Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
				.Take(queryModel.JobOffersPerPage)
				.Select(j => new JobOfferAllViewModel
				{
					Id = j.Id.ToString(),
					JobPosition = j.JobPosition,
					CompanyImageUrl = j.Company.ImageUrl!,
					CompanyName = j.Company.Name,
					CreatedOn = j.CreatedOn.ToString(CreatedOnDateFormat, CultureInfo.InvariantCulture),
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

		public async Task SaveJobAsync(string jobOfferId, string userId)
		{
			var jobOffer = await this.dbContext
				.JobOffers
				.FirstAsync(j => j.Id.ToString() == jobOfferId);

			var model = new SavedJobOffer()
			{
				Date = DateTime.UtcNow,
				JobOfferId = jobOffer.Id,
				UserId = Guid.Parse(userId)
			};

			await this.dbContext.SavedJobOffers.AddAsync(model);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<bool> IsJobOfferSaved(string jobOfferId, string userId)
		{
			var result = await this.dbContext
				.SavedJobOffers.FirstOrDefaultAsync(j => j.JobOfferId.ToString() == jobOfferId &&
														 j.UserId.ToString() == userId);

			return result != null;
		}

		public async Task RemoveSaveJobAsync(string jobOfferId, string userId)
		{
			var model = await this.dbContext
				.SavedJobOffers
				.FirstAsync(j => j.JobOfferId.ToString() == jobOfferId &&
								 j.UserId.ToString() == userId);

			this.dbContext.SavedJobOffers.Remove(model);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<JobOfferSavedViewModel>> AllSavedJobOffersByUserIdAsync(string userId)
		{
			var savedJobOffers = await this.dbContext
				.SavedJobOffers
				.Where(j => j.UserId.ToString() == userId)
				.Select(j => new JobOfferSavedViewModel()
				{
					JobOfferId = j.JobOfferId.ToString(),
					JobTitle = j.JobOffer.JobPosition,
					CompanyName = j.JobOffer.Company.Name,
					CompanyId = j.JobOffer.CompanyId.ToString(),
					SavedDate = j.Date.ToString(CreatedOnDateForCompany),
				}).ToListAsync();

			return savedJobOffers;
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
				.FirstOrDefaultAsync(j => j.Id.ToString() == id);

			var techStack = jobOffer!
				.JobOfferTechnologies
				.Select(tj => new TechnologyViewModel()
				{
					Id = tj.Technology.Id.ToString(),
					Name = tj.Technology.Name,
					ImageUrl = tj.Technology.ImageUrl,
				}).ToList();

			var model = new JobOfferDetailsViewModel()
			{
				Id = jobOffer!.Id.ToString(),
				Title = jobOffer.JobPosition,
				Description = jobOffer.Description,
				JobLocation = jobOffer.PlaceToWork,
				Salary = GetSalary(jobOffer.MinSalary, jobOffer.MaxSalary),
				CreatedOn = jobOffer.CreatedOn.ToString(CreatedOnDateFormat, CultureInfo.InvariantCulture),
				Company = new Web.ViewModels.Company.CompanyViewModel()
				{
					Id = jobOffer.Company.Id.ToString(),
					Name = jobOffer.Company.Name,
					ImageUrl = jobOffer.Company.ImageUrl!,
				},
				TechStack = techStack,
			};

			if (!string.IsNullOrWhiteSpace(jobOffer.Company.Description))
			{
				string[] words = jobOffer.Company.Description.Split(' ');

				string truncatedDescription = words.Length <= 69 ? jobOffer.Company.Description : string.Join(" ", words.Take(69)) + "...";

				model.Company.Info = truncatedDescription;
			}


			return model;
		}

		public async Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyIdAsync(string userId)
		{
			var company = await this.dbContext
				.Companies
				.FirstAsync(c => c.CreatorId.ToString() == userId);

			var jobOffers = company.JobOffers.Select(j => new JobOfferAllViewModel()
			{
				Id = j.Id.ToString(),
				CompanyName = company.Name,
				CompanyImageUrl = company.ImageUrl!,
				CreatedOn = j.CreatedOn.ToString(CreatedOnDateForCompany, CultureInfo.InvariantCulture),
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
				MaxSalary = jobOffer.MaxSalary,
				MinSalary = jobOffer.MinSalary,
				SalaryType = jobOffer.SalaryType,
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

			var staffs = new List<StaffFilter>()
			{
				new StaffFilter
				{
					Staff = "1-9"
				},
				new StaffFilter
				{
					Staff = "10-30"
				},
				new StaffFilter
				{
					Staff = "31-70"
				},
				new StaffFilter
				{
					Staff = "70+"
				},
			};

			return new AllFilterViewModel()
			{
				Locations = locations,
				Experiences = experiences,
				Staffs = staffs
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

			if (model.SalaryType.HasValue)
			{
				jobOffer.SalaryType = model.SalaryType.Value;

				if (model.SalaryType!.Value == SalaryType.Range)
				{
					jobOffer.MinSalary = model.MinSalary;
					jobOffer.MaxSalary = model.MaxSalary;
				}
				else
				{
					jobOffer.MaxSalary = model.MaxSalary;
				}

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

			var jobOffer = new JobOffer()
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

			if (model.SalaryType.HasValue)
			{
				jobOffer.SalaryType = model.SalaryType.Value;

				if (model.SalaryType!.Value == SalaryType.Range)
				{
					jobOffer.MinSalary = model.MinSalary;
					jobOffer.MaxSalary = model.MaxSalary;
				}
				else
				{
					jobOffer.MaxSalary = model.MaxSalary;
				}
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

		private static void OrderFilters(AllJobOffersQueryModel queryModel)
		{
			queryModel.Filters.Locations = queryModel.Filters.Locations.OrderByDescending(l => l.Count).ToList();
			queryModel.Filters.Experiences = queryModel.Filters.Experiences.OrderByDescending(l => l.Count).ToList();

			var experiences = queryModel.Filters.Experiences.ToList();
			var juniorExperience = experiences.FirstOrDefault(e => e.Seniority == "Junior");

			if (juniorExperience != null)
			{
				experiences.Remove(juniorExperience);
				experiences.Insert(0, juniorExperience);
			}

			queryModel.Filters.Experiences = experiences;
		}

		private static async Task CountFilters(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
		{
			foreach (var location in queryModel.Filters.Locations)
			{
				location.Count = await jobOffersQuery
					.CountAsync(j => j.PlaceToWork == location.Location);
			}

			foreach (var filter in queryModel.Filters.Experiences)
			{
				filter.Count = await jobOffersQuery
					.CountAsync(j => j.WorkingExperience == filter.Seniority);
			}

			foreach (var filter in queryModel.Filters.Staffs)
			{
				var digits = ExtractDigits(filter.Staff);

				if (digits.Item2 == -1)
				{
					filter.Count = await jobOffersQuery
						.CountAsync(j => j.Company.EmployeeCount > digits.Item1);
				}
				else
				{
					filter.Count = await jobOffersQuery
						.CountAsync(j => j.Company.EmployeeCount >= digits.Item1 &&
										 j.Company.EmployeeCount <= digits.Item2);
				}
			}
		}

		private static IQueryable<JobOffer> FilterJobOffers(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
		{
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

			if (queryModel.Salary)
			{
				jobOffersQuery = jobOffersQuery.Where(j => j.MaxSalary.HasValue);
			}

			if (!string.IsNullOrWhiteSpace(queryModel.EmployeesCnt))
			{
				var staffCountSet = new HashSet<string>(queryModel.EmployeesCnt.Split(","));

				foreach (var range in staffCountSet)
				{
					var digits = ExtractDigits(range);

					if (digits.Item2 == -1)
					{
						jobOffersQuery = jobOffersQuery
							.Where(j => j.Company.EmployeeCount > digits.Item1);
					}
					else
					{
						jobOffersQuery = jobOffersQuery
							.Where(j => j.Company.EmployeeCount >= digits.Item1 &&
										j.Company.EmployeeCount <= digits.Item2);
					}
				}

				foreach (var filter in queryModel.Filters.Staffs)
				{
					if (staffCountSet.Contains(filter.Staff))
						filter.IsChecked = true;
				}
			}

			return jobOffersQuery;
		}

		private static string GetSalary(decimal? minSalary, decimal? maxSalary)
		{
			if (minSalary == null && maxSalary == null)
			{
				return string.Empty;
			}

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

		private static (int, int) ExtractDigits(string input)
		{
			Regex regex = new Regex(@"(\d+)(?:-(\d+))?");

			Match match = regex.Match(input);
			if (match.Success)
			{
				int firstNumber = int.Parse(match.Groups[1].Value);
				int secondNumber = -1;
				if (match.Groups[2].Success)
					secondNumber = int.Parse(match.Groups[2].Value);
				return (firstNumber, secondNumber);
			}

			return (-1, -1);
		}
	}
}