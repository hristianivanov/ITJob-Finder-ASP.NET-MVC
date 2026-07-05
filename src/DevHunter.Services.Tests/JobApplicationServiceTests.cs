namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Interfaces;
    using Web.ViewModels.JobApplication;

    using DevHunter.Data;
    using DevHunter.Data.Models.Enums;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    [TestFixture]
    public class JobApplicationServiceTests
    {
        private DevHunterDbContext dbContext;
        private DbContextOptions<DevHunterDbContext> dbOptions;

        private IJobApplicationService jobApplicationService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            jobApplicationService =
                new JobApplicationService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task ApplyJobOfferAsync_AppliesJobOfferCorrect()
        {
            var model = new JobApplicationFormModel()
            {
                CandidateName = "candidate_name",
                Email = "candidate@gmail.com",
                MotivationalLetter = "letter",
            };

            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var user = await dbContext.Users.FirstAsync();

            var result = await jobApplicationService.ApplyJobOfferAsync(model, jobOffer.Id, user.Id);

            var addedApplication = await dbContext.JobApplications.FirstAsync(j => j.Id.ToString() == result);

            addedApplication.Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(model, options => options.ExcludingMissingMembers());
        }

        [Test]
        public async Task ApplyJobOfferAsync_ShouldThrowExceptionForNullableFormModel()
        {
            var act = async () => await jobApplicationService.ApplyJobOfferAsync(null!, Guid.Empty, Guid.Empty);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task ApplyJobOfferAsync_ShouldThrowExceptionForInvalidJobOfferId()
        {
            var model = new JobApplicationFormModel()
            {
                CandidateName = "candidate_name",
                Email = "candidate@gmail.com",
                MotivationalLetter = "letter",
            };

            var act = async () => await jobApplicationService.ApplyJobOfferAsync(model, Guid.Empty, Guid.Empty);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task ApplyJobOfferAsync_ShouldRejectMissingJobOffer()
        {
            var model = new JobApplicationFormModel
            {
                CandidateName = "candidate_name",
                Email = "candidate@gmail.com",
                MotivationalLetter = "letter",
            };

            var act = async () => await jobApplicationService
                .ApplyJobOfferAsync(model, Guid.NewGuid(), Guid.Empty);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task ApplyJobOfferAsync_ShouldRejectInvalidAuthenticatedUserId()
        {
            var model = new JobApplicationFormModel
            {
                CandidateName = "candidate_name",
                Email = "candidate@gmail.com",
                MotivationalLetter = "letter",
            };
            var jobOffer = await dbContext.JobOffers.FirstAsync();

            var act = async () => await jobApplicationService
                .ApplyJobOfferAsync(model, jobOffer.Id, Guid.NewGuid());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task AllCandidatesByCompanyIdAsync_ShouldReturnAllCandidatesForTheCompanyCorrect()
        {
            var company = await dbContext.Companies.FirstAsync();

            var result = await jobApplicationService.AllCandidatesByCompanyIdAsync(company.Id);

            var jobOfferApplications = await dbContext.JobOffers
                .Where(j => j.CompanyId == company.Id && j.JobApplications.Count != 0).ToListAsync();

            result.Should()
                .NotBeNullOrEmpty()
                .And
                .BeOfType<List<AllJobApplicationViewModel>>()
                .And
                .Equal(jobOfferApplications, (j1, j2) => j1.JobOfferId == j2.Id.ToString())
                .And
                .HaveCount(jobOfferApplications.Count);
        }

        [Test]
        public async Task AllCandidatesByCompanyIdAsync_ShouldReturnNothingForNonExistingCompany()
        {
            var result = await jobApplicationService.AllCandidatesByCompanyIdAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }

        [Test]
        public async Task AllCandidatesByCompanyIdAsync_ShouldReturnNothingForNullCompanyId()
        {
            var result = await jobApplicationService.AllCandidatesByCompanyIdAsync(null);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task GetApplicationById_ShouldReturnApplication()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();

            var result = await jobApplicationService
                .GetApplicationById(jobApplication.Id, company.CreatorId);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<JobApplicationViewModel>();

            result.Id.Should().Be(jobApplication.Id.ToString());
        }

        [Test]
        public async Task AllUserApplicationsAsync_ShouldReturnAllUsersApplications()
        {
            var user = await dbContext.Users.FirstAsync();

            var userApplications = await dbContext.UsersJobApplications.Where(x => x.UserId == user.Id).ToListAsync();

            var result = await jobApplicationService.AllUserApplicationsAsync(user.Id);

            result.Should()
                .NotBeNull()
                .And
                .BeOfType<List<MyApplicationViewModel>>()
                .And
                .BeEquivalentTo(userApplications)
                .And
                .HaveCount(userApplications.Count);
        }

        [Test]
        public async Task AllUserApplicationsAsync_ShouldReturnEmptyListForNonExistingUser()
        {
            var result = await jobApplicationService.AllUserApplicationsAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();

            var result = await jobApplicationService.ExistsByIdAsync(jobApplication.Id);

            result.Should().BeTrue();
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse()
        {
            var result = await jobApplicationService.ExistsByIdAsync(Guid.NewGuid());

            result.Should().BeFalse();
        }

        [Test]
        public async Task ApproveApplicationAsync_ShouldApproveApplicationCorrect()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();

            await jobApplicationService
                .ApproveApplicationAsync(jobApplication.Id, company.CreatorId);

            jobApplication.Status.Should()
                .BeDefined()
                .And
                .Be(ApplicationStatus.Approved);
        }

        [Test]
        public async Task ApproveApplicationAsync_ShouldThrowExceptionForNonExistingApplication()
        {
            var company = await dbContext.Companies.FirstAsync();
            var act = async () => await jobApplicationService
                .ApproveApplicationAsync(Guid.NewGuid(), company.CreatorId);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task RejectApplicationAsync_ShouldRejectApplicationCorrect()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();

            await jobApplicationService
                .RejectApplicationAsync(jobApplication.Id, company.CreatorId);

            jobApplication.Status.Should()
                .BeDefined()
                .And
                .Be(ApplicationStatus.Rejected);
        }

        [Test]
        public async Task RejectApplicationAsync_ShouldThrowExceptionForNonExistingApplication()
        {
            var company = await dbContext.Companies.FirstAsync();
            var act = async () => await jobApplicationService
                .RejectApplicationAsync(Guid.NewGuid(), company.CreatorId);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task IsOwnedByCompanyAsync_ShouldRejectAnotherUser()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();
            var otherUser = await dbContext.Users.FirstAsync(user => user.Id != company.CreatorId);

            bool ownedByCompany = await jobApplicationService
                .IsOwnedByCompanyAsync(jobApplication.Id, company.CreatorId);
            bool ownedByOtherUser = await jobApplicationService
                .IsOwnedByCompanyAsync(jobApplication.Id, otherUser.Id);

            ownedByCompany.Should().BeTrue();
            ownedByOtherUser.Should().BeFalse();
        }

        [Test]
        public async Task ApproveApplicationAsync_ShouldRejectAnotherCompanyUser()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();
            var otherUser = await dbContext.Users.FirstAsync(user => user.Id != company.CreatorId);

            var act = async () => await jobApplicationService
                .ApproveApplicationAsync(jobApplication.Id, otherUser.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task ApproveApplicationAsync_ShouldAllowDuplicateApproval()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();

            await jobApplicationService
                .ApproveApplicationAsync(jobApplication.Id, company.CreatorId);
            var act = async () => await jobApplicationService
                .ApproveApplicationAsync(jobApplication.Id, company.CreatorId);

            await act.Should().NotThrowAsync();
            jobApplication.Status.Should().Be(ApplicationStatus.Approved);
        }

        // ── RejectApplicationAsync – missing coverage ────────────────────────────

        [Test]
        public async Task RejectApplicationAsync_ShouldRejectAnotherCompanyUser()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();
            var otherUser = await dbContext.Users.FirstAsync(user => user.Id != company.CreatorId);

            var act = async () => await jobApplicationService
                .RejectApplicationAsync(jobApplication.Id, otherUser.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task RejectApplicationAsync_ShouldAllowDuplicateRejection()
        {
            var jobApplication = await dbContext.JobApplications.FirstAsync();
            var company = await dbContext.Companies.FirstAsync();

            await jobApplicationService
                .RejectApplicationAsync(jobApplication.Id, company.CreatorId);
            var act = async () => await jobApplicationService
                .RejectApplicationAsync(jobApplication.Id, company.CreatorId);

            await act.Should().NotThrowAsync();
            jobApplication.Status.Should().Be(ApplicationStatus.Rejected);
        }
    }
}
