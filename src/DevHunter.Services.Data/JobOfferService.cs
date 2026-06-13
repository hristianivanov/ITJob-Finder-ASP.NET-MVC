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
                .AsNoTracking();

            jobOffersQuery = FilterJobOffers(queryModel, jobOffersQuery);

            if (await jobOffersQuery.AnyAsync(j => j.MaxSalary.HasValue))
            {
                queryModel.Filters.IsSalaryAvailable = true;
            }

            await CountFilters(queryModel, jobOffersQuery);

            OrderFilters(queryModel);

            IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
                .Take(queryModel.JobOffersPerPage)
                .Select(ToAllViewModel())
                .ToArrayAsync();

            int totalJobOffers = await jobOffersQuery.CountAsync();

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
                .AsNoTracking();

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
                .Select(ToAllViewModel())
                .ToArrayAsync();

            int totalJobOffers = await jobOffersQuery.CountAsync();

            return new AllJobOffersFilteredAndPagedServiceModel()
            {
                TotalJobOffersCount = totalJobOffers,
                JobOffers = allJobOffers
            };
        }

        public async Task SaveJobAsync(string jobOfferId, string userId)
        {
            if (!TryParseIds(jobOfferId, userId, out Guid parsedJobOfferId, out Guid parsedUserId))
            {
                throw new InvalidOperationException("A valid job offer and user are required.");
            }

            bool jobOfferExists = await this.dbContext.JobOffers
                .AsNoTracking()
                .AnyAsync(j => j.Id == parsedJobOfferId);

            if (!jobOfferExists)
            {
                throw new InvalidOperationException("Job offer does not exist.");
            }

            bool alreadySaved = await this.dbContext.SavedJobOffers
                .AnyAsync(j => j.JobOfferId == parsedJobOfferId && j.UserId == parsedUserId);

            if (alreadySaved)
            {
                return;
            }

            var model = new SavedJobOffer
            {
                Date = DateTime.UtcNow,
                JobOfferId = parsedJobOfferId,
                UserId = parsedUserId
            };

            await this.dbContext.SavedJobOffers.AddAsync(model);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsJobOfferSaved(string jobOfferId, string userId)
        {
            if (!TryParseIds(jobOfferId, userId, out Guid parsedJobOfferId, out Guid parsedUserId))
            {
                return false;
            }

            return await this.dbContext.SavedJobOffers
                .AsNoTracking()
                .AnyAsync(j => j.JobOfferId == parsedJobOfferId && j.UserId == parsedUserId);
        }

        public async Task RemoveSaveJobAsync(string jobOfferId, string userId)
        {
            if (!TryParseIds(jobOfferId, userId, out Guid parsedJobOfferId, out Guid parsedUserId))
            {
                return;
            }

            var model = await this.dbContext.SavedJobOffers
                .FirstOrDefaultAsync(j => j.JobOfferId == parsedJobOfferId && j.UserId == parsedUserId);

            if (model != null)
            {
                this.dbContext.SavedJobOffers.Remove(model);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JobOfferSavedViewModel>> AllSavedJobOffersByUserIdAsync(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return Array.Empty<JobOfferSavedViewModel>();
            }

            var savedJobOffers = await this.dbContext
                .SavedJobOffers
                .AsNoTracking()
                .Where(j => j.UserId == parsedUserId)
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
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                return false;
            }

            return await this.dbContext.JobOffers
                .AsNoTracking()
                .AnyAsync(j => j.Id == parsedId);
        }

        public async Task<bool> IsOwnedByCompanyAsync(string id, string userId)
        {
            if (!TryParseIds(id, userId, out Guid parsedId, out Guid parsedUserId))
            {
                return false;
            }

            return await this.dbContext.JobOffers
                .AsNoTracking()
                .AnyAsync(j => j.Id == parsedId && j.Company.CreatorId == parsedUserId);
        }

        public async Task<JobOfferDetailsViewModel> GetDetailsByIdAsync(string id)
        {
            Guid parsedId = ParseRequiredId(id, "job offer");

            var jobOffer = await this.dbContext
                .JobOffers
                .AsNoTracking()
                .Include(j => j.Company)
                .Include(j => j.JobOfferTechnologies)
                .ThenInclude(technologyJobOffer => technologyJobOffer.Technology)
                .FirstOrDefaultAsync(j => j.Id == parsedId)
                ?? throw new InvalidOperationException("Job offer does not exist.");

            var techStack = jobOffer
                .JobOfferTechnologies
                .Select(tj => new TechnologyViewModel()
                {
                    Id = tj.Technology.Id.ToString(),
                    Name = tj.Technology.Name,
                    ImageUrl = tj.Technology.ImageUrl,
                }).ToList();

            var model = new JobOfferDetailsViewModel()
            {
                Id = jobOffer.Id.ToString(),
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
            Guid parsedUserId = ParseRequiredId(userId, "user");

            bool companyExists = await this.dbContext.Companies
                .AsNoTracking()
                .AnyAsync(company => company.CreatorId == parsedUserId);

            if (!companyExists)
            {
                throw new InvalidOperationException("Company does not exist.");
            }

            return await this.dbContext.JobOffers
                .AsNoTracking()
                .Where(jobOffer => jobOffer.Company.CreatorId == parsedUserId)
                .Select(jobOffer => new JobOfferAllViewModel
                {
                    Id = jobOffer.Id.ToString(),
                    CompanyName = jobOffer.Company.Name,
                    CompanyImageUrl = jobOffer.Company.ImageUrl!,
                    CreatedOn = jobOffer.CreatedOn.ToString(CreatedOnDateForCompany, CultureInfo.InvariantCulture),
                    JobLocation = jobOffer.PlaceToWork,
                    JobPosition = jobOffer.JobPosition,
                    Salary = GetSalary(jobOffer.MinSalary, jobOffer.MaxSalary),
                    Technologies = jobOffer.JobOfferTechnologies.Select(technologyJobOffer => new TechnologyViewModel
                    {
                        Id = technologyJobOffer.TechnologyId.ToString(),
                        ImageUrl = technologyJobOffer.Technology.ImageUrl!,
                        Name = technologyJobOffer.Technology.Name,
                    }),
                })
                .ToListAsync();
        }

        public async Task<JobOfferEditFormModel> GetForEditByIdAsync(string id)
        {
            Guid parsedId = ParseRequiredId(id, "job offer");

            var jobOffer = await this.dbContext
                .JobOffers
                .AsNoTracking()
                .Include(j => j.JobOfferTechnologies)
                .ThenInclude(j => j.Technology)
                .FirstOrDefaultAsync(j => j.Id == parsedId)
                ?? throw new InvalidOperationException("Job offer does not exist.");

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
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                return;
            }

            var jobOffer = await this.dbContext
                .JobOffers
                .FirstOrDefaultAsync(t => t.Id == parsedId);

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
                .AsNoTracking()
                .Select(j => j.PlaceToWork)
                .Distinct()
                .Select(place => new LocationFilter
                {
                    Location = place,
                })
                .ToListAsync();

            var experiences = await this.dbContext
                .JobOffers
                .AsNoTracking()
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
            Guid parsedId = ParseRequiredId(id, "job offer");

            var jobOffer = await this.dbContext
                .JobOffers
                .FirstOrDefaultAsync(j => j.Id == parsedId)
                ?? throw new InvalidOperationException("Job offer does not exist.");

            bool isChanged = UpdateJobOfferFields(jobOffer, model);
            isChanged |= await AddTechnologiesAsync(jobOffer, model.Technologies, skipExisting: true);

            if (isChanged)
            {
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<string> CreateAndReturnIdAsync(JobOfferFormModel model, string userId)
        {
            Guid parsedUserId = ParseRequiredId(userId, "user");

            var company = await this.dbContext
                .Companies
                .FirstOrDefaultAsync(c => c.CreatorId == parsedUserId)
                ?? throw new InvalidOperationException("Company does not exist.");

            JobOffer jobOffer = CreateJobOffer(model, company.Id);
            await AddTechnologiesAsync(jobOffer, model.Technologies, skipExisting: false);

            await this.dbContext.JobOffers.AddAsync(jobOffer);
            await this.dbContext.SaveChangesAsync();

            return jobOffer.Id!.ToString();
        }

        private async Task<bool> AddTechnologiesAsync(JobOffer jobOffer, string? serializedTechnologies, bool skipExisting)
        {
            if (string.IsNullOrWhiteSpace(serializedTechnologies) || serializedTechnologies == "[]")
            {
                return false;
            }

            string[] technologyNames = JsonConvert.DeserializeObject<string[]>(serializedTechnologies)
                ?? Array.Empty<string>();

            var technologies = await this.dbContext.Technologies
                .Where(technology => technologyNames.Contains(technology.Name))
                .ToListAsync();

            if (skipExisting)
            {
                var existingTechnologyIds = await this.dbContext.TechnologyJobOffers
                    .Where(technologyJobOffer => technologyJobOffer.JobOfferId == jobOffer.Id)
                    .Select(technologyJobOffer => technologyJobOffer.TechnologyId)
                    .ToListAsync();

                technologies = technologies
                    .Where(technology => !existingTechnologyIds.Contains(technology.Id))
                    .ToList();
            }

            var jobOfferTechnologies = technologies
                .Select(technology => new TechnologyJobOffers
                {
                    JobOfferId = jobOffer.Id,
                    TechnologyId = technology.Id
                })
                .ToList();

            await this.dbContext.TechnologyJobOffers.AddRangeAsync(jobOfferTechnologies);
            return true;
        }

        private static JobOffer CreateJobOffer(JobOfferFormModel model, Guid companyId)
        {
            var sanitizer = new HtmlSanitizer();
            var jobOffer = new JobOffer
            {
                JobPosition = model.Title,
                Description = sanitizer.Sanitize(model.Description),
                CreatedOn = DateTime.UtcNow,
                JobPlace = model.LocationType!.Value,
                PlaceToWork = model.LocationType.Value == PlaceToWork.Remote ? "Remote" : model.Location!,
                WorkingExperience = model.WorkingExperience,
                CompanyId = companyId,
            };

            if (model.WorkingHours.HasValue)
            {
                jobOffer.WorkingHours = model.WorkingHours.Value;
            }

            ApplySalary(jobOffer, model.SalaryType, model.MinSalary, model.MaxSalary);
            return jobOffer;
        }

        private static bool UpdateJobOfferFields(JobOffer jobOffer, JobOfferEditFormModel model)
        {
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
                ApplySalary(jobOffer, model.SalaryType, model.MinSalary, model.MaxSalary);
                isChanged = true;
            }

            if (model.WorkingHours != jobOffer.WorkingHours && model.WorkingHours.HasValue)
            {
                jobOffer.WorkingHours = model.WorkingHours.Value;
                isChanged = true;
            }

            if (model.Description != jobOffer.Description)
            {
                var sanitizer = new HtmlSanitizer();
                jobOffer.Description = sanitizer.Sanitize(model.Description);
                isChanged = true;
            }

            return isChanged;
        }

        private static void ApplySalary(JobOffer jobOffer, SalaryType? salaryType, decimal? minSalary, decimal? maxSalary)
        {
            if (!salaryType.HasValue)
            {
                return;
            }

            jobOffer.SalaryType = salaryType.Value;
            if (salaryType.Value == SalaryType.Range)
            {
                jobOffer.MinSalary = minSalary;
                jobOffer.MaxSalary = maxSalary;
            }
            else
            {
                jobOffer.MaxSalary = maxSalary;
            }
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
            jobOffersQuery = FilterByLocation(queryModel, jobOffersQuery);
            jobOffersQuery = FilterByExperience(queryModel, jobOffersQuery);
            jobOffersQuery = FilterBySalary(queryModel, jobOffersQuery);
            jobOffersQuery = FilterByStaffCount(queryModel, jobOffersQuery);
            return jobOffersQuery;
        }

        private static IQueryable<JobOffer> FilterByLocation(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
        {
            if (string.IsNullOrWhiteSpace(queryModel.JobLocation))
            {
                return jobOffersQuery;
            }

            var locationSet = new HashSet<string>(queryModel.JobLocation.Split(','));
            foreach (var filter in queryModel.Filters.Locations)
            {
                if (locationSet.Contains(filter.Location))
                {
                    filter.IsChecked = true;
                }
            }

            return jobOffersQuery.Where(jobOffer => locationSet.Contains(jobOffer.PlaceToWork));
        }

        private static IQueryable<JobOffer> FilterByExperience(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
        {
            if (string.IsNullOrWhiteSpace(queryModel.Experience))
            {
                return jobOffersQuery;
            }

            var experienceSet = new HashSet<string>(queryModel.Experience.Split(","));
            foreach (var filter in queryModel.Filters.Experiences)
            {
                if (experienceSet.Contains(filter.Seniority))
                {
                    filter.IsChecked = true;
                }
            }

            return jobOffersQuery.Where(jobOffer => experienceSet.Contains(jobOffer.WorkingExperience!));
        }

        private static IQueryable<JobOffer> FilterBySalary(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
            => queryModel.Salary
                ? jobOffersQuery.Where(jobOffer => jobOffer.MaxSalary.HasValue)
                : jobOffersQuery;

        private static IQueryable<JobOffer> FilterByStaffCount(AllJobOffersQueryModel queryModel, IQueryable<JobOffer> jobOffersQuery)
        {
            if (string.IsNullOrWhiteSpace(queryModel.EmployeesCnt))
            {
                return jobOffersQuery;
            }

            var staffCountSet = new HashSet<string>(queryModel.EmployeesCnt.Split(","));
            foreach (string range in staffCountSet)
            {
                (int minimum, int maximum) = ExtractDigits(range);
                jobOffersQuery = maximum == -1
                    ? jobOffersQuery.Where(jobOffer => jobOffer.Company.EmployeeCount > minimum)
                    : jobOffersQuery.Where(jobOffer =>
                        jobOffer.Company.EmployeeCount >= minimum &&
                        jobOffer.Company.EmployeeCount <= maximum);
            }

            foreach (var filter in queryModel.Filters.Staffs)
            {
                if (staffCountSet.Contains(filter.Staff))
                {
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

        private static System.Linq.Expressions.Expression<Func<JobOffer, JobOfferAllViewModel>> ToAllViewModel()
        {
            return jobOffer => new JobOfferAllViewModel
            {
                Id = jobOffer.Id.ToString(),
                JobPosition = jobOffer.JobPosition,
                CompanyImageUrl = jobOffer.Company.ImageUrl!,
                CompanyName = jobOffer.Company.Name,
                CreatedOn = jobOffer.CreatedOn.ToString(CreatedOnDateFormat, CultureInfo.InvariantCulture),
                PlaceToWorkType = jobOffer.JobPlace.ToString(),
                JobLocation = jobOffer.PlaceToWork,
                Technologies = jobOffer.JobOfferTechnologies
                    .Select(technologyJobOffer => new TechnologyViewModel
                    {
                        Id = technologyJobOffer.Technology.Id.ToString(),
                        Name = technologyJobOffer.Technology.Name,
                        ImageUrl = technologyJobOffer.Technology.ImageUrl,
                    })
                    .ToList(),
                Salary = GetSalary(jobOffer.MinSalary, jobOffer.MaxSalary),
            };
        }

        private static Guid ParseRequiredId(string id, string entityName)
        {
            if (Guid.TryParse(id, out Guid parsedId))
            {
                return parsedId;
            }

            throw new InvalidOperationException($"A valid {entityName} id is required.");
        }

        private static bool TryParseIds(string firstId, string secondId, out Guid parsedFirstId, out Guid parsedSecondId)
        {
            bool firstIdIsValid = Guid.TryParse(firstId, out parsedFirstId);
            bool secondIdIsValid = Guid.TryParse(secondId, out parsedSecondId);

            return firstIdIsValid && secondIdIsValid;
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
