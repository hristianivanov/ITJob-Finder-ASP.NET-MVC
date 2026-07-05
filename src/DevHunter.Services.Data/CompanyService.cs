namespace DevHunter.Services.Data
{
    using System.Globalization;
    using System.Linq.Expressions;

    using Ganss.Xss;
    using Microsoft.EntityFrameworkCore;

    using DevHunter.Common;
    using DevHunter.Data;
    using DevHunter.Data.Models;

    using Interfaces;
    using Web.ViewModels.User;
    using Web.ViewModels.JobOffer;
    using Web.ViewModels.Technology;
    using Web.ViewModels.Company;

    using static Common.GeneralApplicationConstants.JobOffer;

    public class CompanyService : ICompanyService
    {
        private readonly DevHunterDbContext context;
        private readonly IImageService imageService;

        public CompanyService(DevHunterDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task AddAsync(CompanyRegisterFormModel model, Guid userId)
        {
            var company = new Company()
            {
                Name = model.Name,
                CreatorId = userId,
                WebsiteUrl = model.WebsiteUrl,
                ImageUrl = await this.imageService.UploadImage(model.Image, "DevHunter/companies", model.Name),
            };

            await context.Companies.AddAsync(company);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.context.Companies
                .AsNoTracking()
                .AnyAsync(company => company.Name == name);

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.context.Companies
                .AsNoTracking()
                .AnyAsync(company => company.Id == id);

        public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
            => await this.context.Companies
                .AsNoTracking()
                .AnyAsync(company => company.Id == id && company.CreatorId == userId);

        public async Task<CompanyFormModel> GetForEditByIdAsync(Guid id)
        {
            Guid companyId = id;

            var company = await this.context
                .Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(company => company.Id == companyId)
                ?? throw new InvalidOperationException("Company does not exist.");

            return new CompanyFormModel
            {
                Name = company.Name,
                ImageUrl = company.ImageUrl!,
                Description = company.Description,
                Activity = company.Activity,
                WebsiteUrl = company.WebsiteUrl,
                Sector = company.Sector,
                Address = company.Location,
                EmployeesCnt = company.EmployeeCount,
                FoundedDate = company.FoundedDate,
            };
        }

        public async Task EditAsync(Guid id, CompanyFormModel model, Guid userId)
        {
            ArgumentNullException.ThrowIfNull(model);

            Guid companyId = id;
            Guid creatorId = userId;

            var company = await this.context.Companies
                .FirstOrDefaultAsync(company => company.Id == companyId && company.CreatorId == creatorId)
                ?? throw new InvalidOperationException("Company does not exist or does not belong to the user.");

            var sanitizer = new HtmlSanitizer();

            bool hasChanges = false;

            if (company.Name != model.Name)
            {
                company.Name = model.Name;
                hasChanges = true;
            }
            if (company.Description != model.Description)
            {
                var sanitized = sanitizer.Sanitize(model.Description!);

                company.Description = sanitized;
                hasChanges = true;
            }
            if (company.Activity != model.Activity)
            {
                company.Activity = model.Activity;
                hasChanges = true;
            }
            if (company.WebsiteUrl != model.WebsiteUrl)
            {
                company.WebsiteUrl = model.WebsiteUrl;
                hasChanges = true;
            }
            if (company.Sector != model.Sector)
            {
                company.Sector = model.Sector;
                hasChanges = true;
            }
            if (company.Location != model.Address)
            {
                company.Location = model.Address;
                hasChanges = true;
            }
            if (company.EmployeeCount != model.EmployeesCnt)
            {
                company.EmployeeCount = model.EmployeesCnt;
                hasChanges = true;
            }
            if (company.FoundedDate != model.FoundedDate)
            {
                company.FoundedDate = model.FoundedDate;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Guid?> GetCompanyIdByCreatorIdAsync(Guid userId)
            => await this.context.Companies
                .AsNoTracking()
                .Where(company => company.CreatorId == userId)
                .Select(company => (Guid?)company.Id)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<CompanyAdminViewModel>> AllForAdminAsync()
        {
            var companies = await this.context
                .Companies
                .AsNoTracking()
                .Select(c => new CompanyAdminViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    CEO = c.Creator.UserName ?? string.Empty,
                    OffersCnt = c.JobOffers.Count()
                })
                .ToListAsync();

            return companies;
        }

        public async Task<IEnumerable<CompanyAllViewModel>> AllAsync()
        {
            var companies = await this.context
                .Companies
                .Select(c => new CompanyAllViewModel()
                {
                    Id = c.Id.ToString(),
                    JobOffersCount = c.JobOffers.Count(),
                    EmployeesCount = c.EmployeeCount ?? 0,
                    ImageUrl = c.ImageUrl!,
                    Name = c.Name,
                })
                .AsNoTracking()
                .ToListAsync();

            return companies;
        }


        public async Task<CompanyDetailViewModel> GetDetailsByIdAsync(Guid id)
        {
            Guid companyId = id;

            CompanyDetailsData company = await this.context.Companies
                .AsNoTracking()
                .Where(company => company.Id == companyId)
                .Select(CompanyDetailsSelector)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Company does not exist.");

            List<JobOfferAllViewModel> jobOffers = company.JobOffers
                .Select(jobOffer => MapJobOffer(jobOffer, company))
                .ToList();

            return new CompanyDetailViewModel
            {
                Id = company.Id.ToString(),
                Name = company.Name,
                ImageUrl = company.ImageUrl,
                WebsiteUrl = company.WebsiteUrl,
                Sector = company.Sector,
                Activity = company.Activity,
                Location = company.Location,
                Description = company.Description,
                FoundedYear = company.FoundedDate?.Year,
                EmployeesCnt = company.EmployeeCount,
                JobOffers = jobOffers,
                Technologies = jobOffers
                    .SelectMany(jobOffer => jobOffer.Technologies)
                    .DistinctBy(technology => technology.Id)
                    .ToList()
            };
        }



        private static JobOfferAllViewModel MapJobOffer(JobOfferDetailsData jobOffer, CompanyDetailsData company)
            => new()
            {
                Id = jobOffer.Id.ToString(),
                CompanyName = company.Name,
                CompanyImageUrl = company.ImageUrl,
                CreatedOn = jobOffer.CreatedOn.ToString(CreatedOnDateFormat, CultureInfo.InvariantCulture),
                JobLocation = jobOffer.PlaceToWork,
                JobPosition = jobOffer.JobPosition,
                Salary = SalaryFormatter.Format(jobOffer.MinSalary, jobOffer.MaxSalary),
                Technologies = jobOffer.Technologies
                    .Select(technology => new TechnologyViewModel
                    {
                        Id = technology.Id.ToString(),
                        ImageUrl = technology.ImageUrl,
                        Name = technology.Name,
                    })
                    .ToList(),
            };

        private static readonly Expression<Func<Company, CompanyDetailsData>> CompanyDetailsSelector =
            company => new CompanyDetailsData
            {
                Id = company.Id,
                Name = company.Name,
                ImageUrl = company.ImageUrl!,
                WebsiteUrl = company.WebsiteUrl,
                Sector = company.Sector,
                Activity = company.Activity,
                Location = company.Location,
                Description = company.Description,
                FoundedDate = company.FoundedDate,
                EmployeeCount = company.EmployeeCount,
                JobOffers = company.JobOffers
                    .Select(jobOffer => new JobOfferDetailsData
                    {
                        Id = jobOffer.Id,
                        CreatedOn = jobOffer.CreatedOn,
                        PlaceToWork = jobOffer.PlaceToWork,
                        JobPosition = jobOffer.JobPosition,
                        MinSalary = jobOffer.MinSalary,
                        MaxSalary = jobOffer.MaxSalary,
                        Technologies = jobOffer.JobOfferTechnologies
                            .Select(jobOfferTechnology => new TechnologyDetailsData
                            {
                                Id = jobOfferTechnology.TechnologyId,
                                ImageUrl = jobOfferTechnology.Technology.ImageUrl!,
                                Name = jobOfferTechnology.Technology.Name,
                            })
                            .ToList(),
                    })
                    .ToList(),
            };

        private sealed class CompanyDetailsData
        {
            public Guid Id { get; init; }
            public string Name { get; init; } = null!;
            public string ImageUrl { get; init; } = null!;
            public string? WebsiteUrl { get; init; }
            public string? Sector { get; init; }
            public string? Activity { get; init; }
            public string? Location { get; init; }
            public string? Description { get; init; }
            public DateTime? FoundedDate { get; init; }
            public int? EmployeeCount { get; init; }
            public List<JobOfferDetailsData> JobOffers { get; init; } = new();
        }

        private sealed class JobOfferDetailsData
        {
            public Guid Id { get; init; }
            public DateTime CreatedOn { get; init; }
            public string PlaceToWork { get; init; } = null!;
            public string JobPosition { get; init; } = null!;
            public decimal? MinSalary { get; init; }
            public decimal? MaxSalary { get; init; }
            public List<TechnologyDetailsData> Technologies { get; init; } = new();
        }

        private sealed class TechnologyDetailsData
        {
            public Guid Id { get; init; }
            public string ImageUrl { get; init; } = null!;
            public string Name { get; init; } = null!;
        }
    }
}
