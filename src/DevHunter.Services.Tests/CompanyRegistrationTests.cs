namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;

    using DevHunter.Data;
    using DevHunter.Data.Models;
    using Services.Data;
    using Services.Data.Interfaces;
    using Web.ViewModels.User;

    public class CompanyRegistrationTests
    {
        private Mock<UserManager<ApplicationUser>> userManager;
        private Mock<ICompanyService> companyService;
        private DevHunterDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            userManager = CreateUserManagerMock();
            companyService = new Mock<ICompanyService>();

            var options = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("CompanyRegistration" + Guid.NewGuid())
                .Options;
            dbContext = new DevHunterDbContext(options);

            companyService
                .Setup(s => s.ExistsByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(false);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task RegisterCompanyAsync_ShouldFailWhenCompanyNameAlreadyExists()
        {
            companyService.Setup(s => s.ExistsByNameAsync(It.IsAny<string>())).ReturnsAsync(true);
            var service = CreateService();

            var result = await service.RegisterCompanyAsync(CreateModel());

            result.Succeeded.Should().BeFalse();
            userManager.Verify(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task RegisterCompanyAsync_ShouldFailWhenUserCreationFails()
        {
            userManager
                .Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Creation failed." }));
            var service = CreateService();

            var result = await service.RegisterCompanyAsync(CreateModel());

            result.Succeeded.Should().BeFalse();
            userManager.Verify(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
            companyService.Verify(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public async Task RegisterCompanyAsync_ShouldFailWhenRoleAssignmentFails()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Role failed." }));
            var service = CreateService();

            var result = await service.RegisterCompanyAsync(CreateModel());

            result.Succeeded.Should().BeFalse();
            companyService.Verify(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public async Task RegisterCompanyAsync_ShouldRethrowWhenCompanyCreationFails()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            companyService
                .Setup(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()))
                .ThrowsAsync(new InvalidOperationException("Company creation failed."));
            var service = CreateService();

            var act = async () => await service.RegisterCompanyAsync(CreateModel());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task RegisterCompanyAsync_ShouldSucceed()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            companyService
                .Setup(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);
            var service = CreateService();

            var result = await service.RegisterCompanyAsync(CreateModel());

            result.Succeeded.Should().BeTrue();
            companyService.Verify(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()), Times.Once);
        }

        private AccountService CreateService()
            => new(userManager.Object, companyService.Object, dbContext);

        private void SetupSuccessfulUserCreation()
        {
            userManager
                .Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
        }

        private static CompanyRegisterFormModel CreateModel()
            => new()
            {
                Name = "Test Company",
                Email = "company@example.com",
                Password = "password",
                FirstName = "Test",
                LastName = "Company",
            };

        private static Mock<UserManager<ApplicationUser>> CreateUserManagerMock()
            => new(
                Mock.Of<IUserStore<ApplicationUser>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<IPasswordHasher<ApplicationUser>>(),
                Array.Empty<IUserValidator<ApplicationUser>>(),
                Array.Empty<IPasswordValidator<ApplicationUser>>(),
                Mock.Of<ILookupNormalizer>(),
                new IdentityErrorDescriber(),
                Mock.Of<IServiceProvider>(),
                Mock.Of<ILogger<UserManager<ApplicationUser>>>());
    }
}
