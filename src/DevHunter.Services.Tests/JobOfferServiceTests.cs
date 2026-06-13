namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Interfaces;
    using Web.ViewModels.JobOffer;
    using Web.ViewModels.Technology;

    using DevHunter.Data;
    using Data.Models.JobOffer;
    using DevHunter.Data.Models.Enums;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    public class JobOfferServiceTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;

        private IJobOfferService jobOfferService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            jobOfferService =
                new JobOfferService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllAsync_ShouldFilterJobOffers()
        {
            var jobOffers = await dbContext
                .JobOffers
                .Where(j => j.PlaceToWork == "Sofia"
                && j.WorkingExperience == "5+ years work experience"
                && j.Company.EmployeeCount >= 10 && j.Company.EmployeeCount <= 30)
                .ToListAsync();

            var model = new AllJobOffersQueryModel()
            {
                JobLocation = "Sofia",
                Salary = true,
                Experience = "5+ years work experience",
                EmployeesCnt = "10-30"
            };

            model.Filters = await jobOfferService.LoadFiltersAsync();

            var result = await jobOfferService.AllAsync(model);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<AllJobOffersFilteredAndPagedServiceModel>();

            result.JobOffers.Should()
                .HaveCount(jobOffers.Count)
                .And
                .Equal(jobOffers, (j1, j2) => j1.Id == j2.Id.ToString());
        }

        [TestCase(1, 6)]
        [TestCase(1, 2)]
        [TestCase(2, 6)]
        public async Task AllAsync_ShouldPageResults(int currPage, int jobOffersPerPage)
        {
            var model = new AllJobOffersQueryModel()
            {
                CurrentPage = currPage,
            };

            var jobOffers = await dbContext
                .JobOffers
                .Skip((currPage - 1) * jobOffersPerPage)
                .Take(jobOffersPerPage)
                .ToListAsync();

            model.Filters = await jobOfferService.LoadFiltersAsync();

            var result = await jobOfferService.AllAsync(model);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<AllJobOffersFilteredAndPagedServiceModel>();

            result.JobOffers.Should()
                .HaveCount(jobOffers.Count)
                .And
                .Equal(jobOffers, (j1, j2) => j1.Id == j2.Id.ToString());
        }

        [Test]
        public async Task LoadFiltersAsync_ShouldLoadFiltersCorrect()
        {
            var locations = await dbContext
                .JobOffers
                .Select(j => j.PlaceToWork)
                .ToListAsync();
            var experiences = await dbContext
                .JobOffers
                .Where(j => !string.IsNullOrWhiteSpace(j.WorkingExperience))
                .Select(j => j.WorkingExperience)
                .ToListAsync();

            var staffs = new List<StaffFilter>
            {
                new StaffFilter { Staff = "1-9" },
                new StaffFilter { Staff = "10-30" },
                new StaffFilter { Staff = "31-70" },
                new StaffFilter { Staff = "70+" },
            };

            var result = await jobOfferService.LoadFiltersAsync();

            result.Should().NotBeNull()
                .And
                .BeOfType<AllFilterViewModel>();

            result.Locations.Should()
                .NotBeNullOrEmpty()
                .And
                .Equal(locations, (l1, l2) => l1.Location == l2);

            result.Experiences.Should()
                .NotBeNullOrEmpty()
                .And
                .Equal(experiences, (e1, e2) => e1.Seniority == e2);

            result.Staffs.Should()
                .HaveCount(4)
                .And
                .OnlyHaveUniqueItems()
                .And
                .Equal(staffs, (s1, s2) => s1.Staff == s2.Staff);
        }

        [Test]
        public async Task AllBySearchAsync_ShouldFilterBySearchString()
        {
            var model = new AllJobOffersQueryModel()
            {
                SearchString = "company_name developer sofia"
            };

            var wildCard = $"%{model.SearchString.ToLower()}%";

            var jobOffers = await dbContext
                .JobOffers
                .Where(j => EF.Functions.Like(j.JobPosition, wildCard) ||
                            EF.Functions.Like(j.Company.Name, wildCard) ||
                            EF.Functions.Like(j.PlaceToWork, wildCard))
                .ToListAsync();

            model.Filters = await jobOfferService.LoadFiltersAsync();

            var result = await jobOfferService.AllBySearchAsync(model);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<AllJobOffersFilteredAndPagedServiceModel>();

            result.JobOffers.Should()
                .HaveCount(jobOffers.Count)
                .And
                .Equal(jobOffers, (j1, j2) => j1.Id == j2.Id.ToString());
        }

        [TestCase(1, 6)]
        [TestCase(1, 2)]
        [TestCase(2, 6)]
        public async Task AllBySearchAsync_ShouldPageResults(int currPage, int jobOffersPerPage)
        {
            var model = new AllJobOffersQueryModel()
            {
                CurrentPage = currPage
            };

            var jobOffers = await dbContext
                .JobOffers
                .Skip((currPage - 1) * jobOffersPerPage)
                .Take(jobOffersPerPage)
                .ToListAsync();

            model.Filters = await jobOfferService.LoadFiltersAsync();

            var result = await jobOfferService.AllBySearchAsync(model);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<AllJobOffersFilteredAndPagedServiceModel>();

            result.JobOffers.Should()
                .HaveCount(jobOffers.Count)
                .And
                .Equal(jobOffers, (j1, j2) => j1.Id == j2.Id.ToString());
        }

        [Test]
        public async Task SaveJobAsync_ShouldSaveJob()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var user = await dbContext.Users.LastAsync();

            await jobOfferService.SaveJobAsync(jobOffer.Id.ToString(), user.Id.ToString());

            var savedJobOffer = await dbContext.SavedJobOffers.FirstOrDefaultAsync(j => j.JobOfferId == jobOffer.Id && j.UserId == user.Id);

            savedJobOffer.Should().NotBeNull();
        }

        [Test]
        public async Task SaveJobAsync_ShouldNotCreateDuplicateSavedJobs()
        {
            var savedJobOffer = await dbContext.SavedJobOffers.FirstAsync();

            await jobOfferService.SaveJobAsync(
                savedJobOffer.JobOfferId.ToString(),
                savedJobOffer.UserId.ToString());

            int savedJobsCount = await dbContext.SavedJobOffers.CountAsync(saved =>
                saved.JobOfferId == savedJobOffer.JobOfferId &&
                saved.UserId == savedJobOffer.UserId);

            savedJobsCount.Should().Be(1);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task SaveJobAsync_ShouldThrowExceptionForNonExistingJobOffer(string nonExistingJobOfferId)
        {
            var user = await dbContext.Users.FirstAsync();

            var act = async () => await jobOfferService.SaveJobAsync(nonExistingJobOfferId, user.Id.ToString());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task SaveJobAsync_ShouldThrowExceptionForNonExistingUser(string? nonExistingUserId)
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var act = async () => await jobOfferService.SaveJobAsync(jobOffer.Id.ToString(), nonExistingUserId!);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task IsJobOfferSaved_ShouldReturnTrueForSavedJobOffer()
        {
            var savedJobOffer = await dbContext.SavedJobOffers.FirstAsync();

            var result = await jobOfferService.IsJobOfferSaved(savedJobOffer.JobOfferId.ToString(), savedJobOffer.UserId.ToString());

            result.Should().BeTrue();
        }

        [TestCase("", "invalid")]
        [TestCase(" ", null)]
        [TestCase(null, " ")]
        [TestCase("invalid", "")]
        public async Task IsJobOfferSaved_ShouldReturnFalse(string? nonExistingJobOfferId, string? nonExistingUserId)
        {
            var result = await jobOfferService.IsJobOfferSaved(nonExistingJobOfferId!, nonExistingUserId!);

            result.Should().BeFalse();
        }

        [Test]
        public async Task RemoveSaveJobAsync_ShouldRemoveSavedJobOffer()
        {
            var savedJobOffer = await dbContext.SavedJobOffers.FirstAsync();

            await jobOfferService.RemoveSaveJobAsync(savedJobOffer.JobOfferId.ToString(), savedJobOffer.UserId.ToString());

            var result = await dbContext.SavedJobOffers.FirstOrDefaultAsync(j => j.JobOfferId == savedJobOffer.JobOfferId && j.UserId == savedJobOffer.UserId);

            result.Should().BeNull();
        }

        [TestCase("", "invalid")]
        [TestCase(" ", null)]
        [TestCase(null, " ")]
        [TestCase("invalid", "")]
        public async Task RemoveSaveJobAsync_ShouldIgnoreInvalidIds(string? nonExistingJobOfferId, string? nonExistingUserId)
        {
            var act = async () => await jobOfferService.RemoveSaveJobAsync(nonExistingJobOfferId!, nonExistingUserId!);

            await act.Should().NotThrowAsync();
        }

        [Test]
        public async Task AllSavedJobOffersByUserIdAsync_ShouldReturnUserSavedJobOffers()
        {
            var user = await dbContext.Users.FirstAsync();

            var savedJobOffers = await dbContext.SavedJobOffers.Where(j => j.UserId == user.Id).ToListAsync();

            var result = await jobOfferService.AllSavedJobOffersByUserIdAsync(user.Id.ToString());

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<List<JobOfferSavedViewModel>>()
                .And
                .Equal(savedJobOffers, (j1, j2) => j1.JobOfferId == j2.JobOfferId.ToString());
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var result = await jobOfferService.ExistsByIdAsync(jobOffer.Id.ToString());

            result.Should().BeTrue();
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task ExistsByIdAsync_ShouldReturnFalse(string nonExistingJobOfferId)
        {
            var result = await jobOfferService.ExistsByIdAsync(nonExistingJobOfferId);

            result.Should().BeFalse();
        }

        [Test]
        public async Task IsOwnedByCompanyAsync_ShouldCheckCompanyOwnership()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();
            var otherUser = await dbContext.Users.FirstAsync(user => user.Id != company.CreatorId);

            bool ownedByCompany = await jobOfferService
                .IsOwnedByCompanyAsync(jobOffer.Id.ToString(), company.CreatorId.ToString());
            bool ownedByOtherUser = await jobOfferService
                .IsOwnedByCompanyAsync(jobOffer.Id.ToString(), otherUser.Id.ToString());

            ownedByCompany.Should().BeTrue();
            ownedByOtherUser.Should().BeFalse();
        }

        [Test]
        public async Task GetDetailsByIdAsync_ShouldReturnCorrectJobOffer()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var result = await jobOfferService.GetDetailsByIdAsync(jobOffer.Id.ToString());

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<JobOfferDetailsViewModel>();

            result.Id.Should().Be(jobOffer.Id.ToString());

            result.TechStack.Should()
                .NotBeNullOrEmpty()
                .And
                .BeOfType<List<TechnologyViewModel>>()
                .And
                .Equal(jobOffer.JobOfferTechnologies, (t1, t2) => t1.Id == t2.TechnologyId.ToString())
                .And
                .HaveCount(jobOffer.JobOfferTechnologies.Count);
        }

        [Test]
        public async Task AllByCompanyIdAsync_ShouldReturnAllCompanyJobOffers()
        {
            var company = await dbContext.Companies.FirstAsync();

            var result = await jobOfferService.AllByCompanyIdAsync(company.CreatorId.ToString());

            result.Should()
                .NotBeNullOrEmpty()
                .And
                .BeOfType<List<JobOfferAllViewModel>>()
                .And
                .Equal(company.JobOffers, (j1, j2) => j1.Id == j2.Id.ToString())
                .And
                .HaveCount(company.JobOffers.Count);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task AllByCompanyIdAsync_ShouldThrowExceptionForNonExistingCompanyUserProfile(string nonCompanyUserProfileId)
        {
            var act = async () => await jobOfferService.AllByCompanyIdAsync(nonCompanyUserProfileId);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task GetForEditByIdAsync_ShouldReturnJobOfferCorrect()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var result = await jobOfferService.GetForEditByIdAsync(jobOffer.Id.ToString());

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<JobOfferEditFormModel>()
                .And
                .BeEquivalentTo(jobOffer, options => options.ExcludingMissingMembers());
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task GetForEditByIdAsync_ShouldThrowExceptionForNonExistingJobOffer(string nonExistingJobOfferId)
        {
            var act = async () => await jobOfferService.GetForEditByIdAsync(nonExistingJobOfferId);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldDeleteJobOffer()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            await jobOfferService.DeleteByIdAsync(jobOffer.Id.ToString());

            var result = await dbContext.JobOffers.FindAsync(jobOffer.Id);

            result.Should().BeNull();
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task DeleteByIdAsync_ShouldNotDeleteJobOfferWithNonExistingId(string nonExistingJobOfferId)
        {
            var jobOffersCntBefore = await dbContext.JobOffers.CountAsync();

            await jobOfferService.DeleteByIdAsync(nonExistingJobOfferId);

            var jobOffersCntAfter = await dbContext.JobOffers.CountAsync();

            jobOffersCntBefore.Should().Be(jobOffersCntAfter);
        }

        [Test]
        public async Task EditJobOfferAsync_ShouldEditJobOfferCorrect()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var model = new JobOfferEditFormModel()
            {
                Title = "new_title",
                Location = "new_location",
                LocationType = PlaceToWork.Remote,
                MinSalary = 20,
                SalaryType = SalaryType.Range,
                MaxSalary = 50,
                WorkingHours = 48,
                Technologies = "[\"React\",\"Javascript\",\"SQL\",\"Spring\"]",
                WorkingExperience = "new_working_experience",
                Description = "new_description",
            };

            await jobOfferService.EditJobOfferAsync(jobOffer.Id.ToString(), model);

            var editedJobOffer = await dbContext.JobOffers.FindAsync(jobOffer.Id);

            editedJobOffer.Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(model, options => options.ExcludingMissingMembers());
        }

        [Test]
        public async Task EditJobOfferAsync_ShouldSanitizeDescription()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();
            var model = new JobOfferEditFormModel
            {
                Title = jobOffer.JobPosition,
                Location = jobOffer.PlaceToWork,
                LocationType = jobOffer.JobPlace,
                Description = "<script>alert('xss')</script><p>Safe description</p>",
                Technologies = "[]",
            };

            await jobOfferService.EditJobOfferAsync(jobOffer.Id.ToString(), model);

            var editedJobOffer = await dbContext.JobOffers.FindAsync(jobOffer.Id);
            editedJobOffer!.Description.Should().NotContain("<script>");
            editedJobOffer.Description.Should().Contain("Safe description");
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task EditJobOfferAsync_ShouldThrowExceptionForNonExistingJobOffer(string? nonExistingJobOfferId)
        {
            var act = async () => await jobOfferService.EditJobOfferAsync(nonExistingJobOfferId!, null!);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task EditJobOfferAsync_ShouldThrowExceptionForNullableModel()
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var act = async () => await jobOfferService.EditJobOfferAsync(jobOffer.Id.ToString(), null!);

            await act.Should().ThrowAsync<NullReferenceException>();
        }

        [Test]
        public async Task CreateAndReturnIdAsync_ShouldCreateJobOfferCorrect()
        {
            var user = await dbContext.Companies.FirstAsync();

            var model = new JobOfferFormModel()
            {
                Title = "new_title",
                Location = "Remote",
                LocationType = PlaceToWork.Remote,
                SalaryType = SalaryType.Range,
                MinSalary = 20,
                MaxSalary = 50,
                WorkingHours = 48,
                Technologies = "[\"React\",\"Javascript\",\"SQL\",\"Spring\"]",
                WorkingExperience = "new_working_experience",
                Description = "new_description",
            };

            var createdJobOfferId = await jobOfferService.CreateAndReturnIdAsync(model, user.CreatorId.ToString());

            var result = await dbContext.JobOffers.FirstOrDefaultAsync(j => j.Id.ToString() == createdJobOfferId);

            result.Should().NotBeNull();
        }

        [Test]
        public async Task CreateAndReturnIdAsync_ShouldSanitizeDescription()
        {
            var company = await dbContext.Companies.FirstAsync();
            var model = new JobOfferFormModel
            {
                Title = "Secure job",
                Location = "Remote",
                LocationType = PlaceToWork.Remote,
                Description = "<script>alert('xss')</script><p>Safe description</p>",
                Technologies = "[]",
            };

            string createdJobOfferId = await jobOfferService
                .CreateAndReturnIdAsync(model, company.CreatorId.ToString());

            var createdJobOffer = await dbContext.JobOffers.FindAsync(Guid.Parse(createdJobOfferId));
            createdJobOffer!.Description.Should().NotContain("<script>");
            createdJobOffer.Description.Should().Contain("Safe description");
        }

        [TestCase(null, null, "")]
        [TestCase(null, 2500, "2 500 lv.")]
        [TestCase(2000, 3500, "2 000 - 3 500 lv.")]
        public async Task AllAsync_ShouldFormatSalary(decimal? minSalary, decimal? maxSalary, string expectedSalary)
        {
            var jobOffer = await dbContext.JobOffers.FirstAsync();
            jobOffer.MinSalary = minSalary;
            jobOffer.MaxSalary = maxSalary;
            await dbContext.SaveChangesAsync();

            var model = new AllJobOffersQueryModel
            {
                Filters = await jobOfferService.LoadFiltersAsync()
            };

            var result = await jobOfferService.AllAsync(model);

            result.JobOffers.Single().Salary.Should().Be(expectedSalary);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("invalid")]
        public async Task CreateAndReturnIdAsync_ShouldThrowExceptionForNonExistingUserCompanyProfile(string? nonExistingJobOfferId)
        {
            var act = async () => await jobOfferService.CreateAndReturnIdAsync(null!, nonExistingJobOfferId!);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task CreateAndReturnIdAsync_ShouldThrowExceptionForNullableModel()
        {
            var user = await dbContext.Companies.FirstAsync();

            var act = async () => await jobOfferService.CreateAndReturnIdAsync(null!, user.CreatorId.ToString());

            await act.Should().ThrowAsync<NullReferenceException>();
        }
    }
}
