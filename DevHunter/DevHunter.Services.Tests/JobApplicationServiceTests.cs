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
		public void Setup()
		{
			dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
				.UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
				.Options;

			dbContext = new DevHunterDbContext(dbOptions);

			dbContext.Database.EnsureCreated();

			SeedDatabase(dbContext);

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

			var result = await jobApplicationService.ApplyJobOfferAsync(model, jobOffer.Id.ToString(), user.Id.ToString());

			var addedApplication = await dbContext.JobApplications.FirstAsync(j => j.Id.ToString() == result);

			addedApplication.Should()
				.NotBeNull()
				.And
				.BeEquivalentTo(model, options => options.ExcludingMissingMembers());
		}

		[Test]
		public async Task ApplyJobOfferAsync_ShouldThrowExceptionForNullableFormModel()
		{
			var act = async () => await jobApplicationService.ApplyJobOfferAsync(null,"","");

			await act.Should().ThrowAsync<NullReferenceException>();
		}

		[Test]
		public async Task ApplyJobOfferAsync_ShouldThrowExceptionForInvalidGuid()
		{
			var model = new JobApplicationFormModel()
			{
				CandidateName = "candidate_name",
				Email = "candidate@gmail.com",
				MotivationalLetter = "letter",
			};

			var act = async () => await jobApplicationService.ApplyJobOfferAsync(model, "", "");

			await act.Should().ThrowAsync<FormatException>();
		}

		[Test]
		public async Task AllCandidatesByCompanyIdAsync_ShouldReturnAllCandidatesForTheCompanyCorrect()
		{
			var company = await dbContext.Companies.FirstAsync();

			var result = await jobApplicationService.AllCandidatesByCompanyIdAsync(company.Id.ToString());

			var jobOfferApplications = await dbContext.JobOffers
				.Where(j => j.CompanyId == company.Id && j.JobApplications.Count != 0).ToListAsync();

			result.Should()
				.NotBeNullOrEmpty()
				.And
				.BeOfType<List<AllJobApplicationViewModel>>()
				.And
				.Equal(jobOfferApplications, (j1,j2) => j1.JobOfferId == j2.Id.ToString())
				.And
				.HaveCount(jobOfferApplications.Count);
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase("invalid")]
		[TestCase(null)]
		public async Task AllCandidatesByCompanyIdAsync_ShouldReturnNothingForNonExistingCompany(string nonExistingCompanyId)
		{
			var result = await jobApplicationService.AllCandidatesByCompanyIdAsync(nonExistingCompanyId);

			result.Should().BeEmpty();
		}

		[Test]
		public async Task GetApplicationById_ShouldReturnApplication()
		{
			var jobApplication = await dbContext.JobApplications.FirstAsync();

			var result = await jobApplicationService.GetApplicationById(jobApplication.Id.ToString());

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

			var result = await jobApplicationService.AllUserApplicationsAsync(user.Id.ToString());

			result.Should()
				.NotBeNull()
				.And
				.BeOfType<List<MyApplicationViewModel>>()
				.And
				.BeEquivalentTo(userApplications)
				.And
				.HaveCount(userApplications.Count);
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase(null)]
		[TestCase("invalid")]
		public async Task AllUserApplicationsAsync_ShouldReturnEmptyListForNonExistingUser(string nonExistingUserId)
		{
			var result = await jobApplicationService.AllUserApplicationsAsync(nonExistingUserId);

			result.Should().BeEmpty();
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrue()
		{
			var jobApplication = await dbContext.JobApplications.FirstAsync();

			var result = await jobApplicationService.ExistsByIdAsync(jobApplication.Id.ToString());

			result.Should().BeTrue();
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase(null)]
		[TestCase("invalid")]
		public async Task ExistsByIdAsync_ShouldReturnFalse(string nonExistingApplicationId)
		{
			var result = await jobApplicationService.ExistsByIdAsync(nonExistingApplicationId);

			result.Should().BeFalse();
		}

		[Test]
		public async Task ApproveApplicationAsync_ShouldApproveApplicationCorrect()
		{
			var jobApplication = await dbContext.JobApplications.FirstAsync();

			await jobApplicationService.ApproveApplicationAsync(jobApplication.Id.ToString());

			jobApplication.Status.Should()
				.BeDefined()
				.And
				.Be(ApplicationStatus.Approved);
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase(null)]
		[TestCase("invalid")]
		public async Task ApproveApplicationAsync_ShouldThrowExceptionForNonExistingApplication(string nonExistingApplicationId)
		{
			var act = async () => await jobApplicationService.ApproveApplicationAsync(nonExistingApplicationId);

			await act.Should().ThrowAsync<InvalidOperationException>();
		}

		[Test]
		public async Task RejectApplicationAsync_ShouldRejectApplicationCorrect()
		{
			var jobApplication = await dbContext.JobApplications.FirstAsync();

			await jobApplicationService.RejectApplicationAsync(jobApplication.Id.ToString());

			jobApplication.Status.Should()
				.BeDefined()
				.And
				.Be(ApplicationStatus.Rejected);
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase(null)]
		[TestCase("invalid")]
		public async Task RejectApplicationAsync_ShouldThrowExceptionForNonExistingApplication(string nonExistingApplicationId)
		{
			var act = async () => await jobApplicationService.RejectApplicationAsync(nonExistingApplicationId);

			await act.Should().ThrowAsync<InvalidOperationException>();
		}

	}
}
