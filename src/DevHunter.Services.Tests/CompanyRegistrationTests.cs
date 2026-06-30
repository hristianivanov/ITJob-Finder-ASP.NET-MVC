namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;

    using DevHunter.Data.Models;
    using Services.Data.Interfaces;
    using Web.Controllers;
    using Web.ViewModels.User;

    public class CompanyRegistrationTests
    {
        private Mock<UserManager<ApplicationUser>> userManager;
        private Mock<SignInManager<ApplicationUser>> signInManager;
        private Mock<ICompanyService> companyService;

        [SetUp]
        public void Setup()
        {
            userManager = CreateUserManagerMock();
            signInManager = CreateSignInManagerMock(userManager.Object);
            companyService = new Mock<ICompanyService>();

            companyService
                .Setup(service => service.ExistsByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(false);
            userManager
                .Setup(manager => manager.SetEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            userManager
                .Setup(manager => manager.SetUserNameAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
        }

        [Test]
        public async Task RegisterCompany_ShouldNotAssignRoleWhenUserCreationFails()
        {
            userManager
                .Setup(manager => manager.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Creation failed." }));
            var controller = CreateController();

            IActionResult result = await controller.RegisterCompany(CreateModel());

            result.Should().BeOfType<ViewResult>();
            userManager.Verify(
                manager => manager.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
                Times.Never);
            companyService.Verify(
                service => service.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()),
                Times.Never);
        }

        [Test]
        public async Task RegisterCompany_ShouldDeleteCreatedUserWhenRoleAssignmentFails()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(manager => manager.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Role assignment failed." }));
            var controller = CreateController();

            IActionResult result = await controller.RegisterCompany(CreateModel());

            result.Should().BeOfType<ViewResult>();
            userManager.Verify(manager => manager.DeleteAsync(It.IsAny<ApplicationUser>()), Times.Once);
            companyService.Verify(
                service => service.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()),
                Times.Never);
        }

        [Test]
        public async Task RegisterCompany_ShouldDeleteCreatedUserWhenCompanyCreationFails()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(manager => manager.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            companyService
                .Setup(service => service.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()))
                .ThrowsAsync(new InvalidOperationException("Company creation failed."));
            var controller = CreateController();

            var act = async () => await controller.RegisterCompany(CreateModel());

            await act.Should().ThrowAsync<InvalidOperationException>();
            userManager.Verify(manager => manager.DeleteAsync(It.IsAny<ApplicationUser>()), Times.Once);
        }

        [Test]
        public async Task RegisterCompany_ShouldSucceedAndRedirectHome()
        {
            SetupSuccessfulUserCreation();
            userManager
                .Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            companyService
                .Setup(s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);
            var controller = CreateController();

            var result = await controller.RegisterCompany(CreateModel());

            var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
            redirect.ActionName.Should().Be("Index");
            redirect.ControllerName.Should().Be("Home");
            companyService.Verify(
                s => s.AddAsync(It.IsAny<CompanyRegisterFormModel>(), It.IsAny<Guid>()),
                Times.Once);
        }

        [Test]
        public async Task RegisterCompany_ShouldReturnViewWhenCompanyNameAlreadyExists()
        {
            companyService
                .Setup(s => s.ExistsByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            var controller = CreateController();

            var result = await controller.RegisterCompany(CreateModel());

            result.Should().BeOfType<ViewResult>();
            userManager.Verify(
                m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
                Times.Never);
        }

        private AccountController CreateController()
            => new(signInManager.Object, userManager.Object, companyService.Object);

        private void SetupSuccessfulUserCreation()
        {
            userManager
                .Setup(manager => manager.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            userManager
                .Setup(manager => manager.DeleteAsync(It.IsAny<ApplicationUser>()))
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

        private static Mock<SignInManager<ApplicationUser>> CreateSignInManagerMock(
            UserManager<ApplicationUser> manager)
            => new(
                manager,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<ILogger<SignInManager<ApplicationUser>>>(),
                Mock.Of<IAuthenticationSchemeProvider>(),
                Mock.Of<IUserConfirmation<ApplicationUser>>());
    }
}
