namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;

    using Web.Areas.Admin.Controllers;
    using Web.Areas.Company.Controllers;
    using Web.Areas.Manage.Controllers;

    using static Common.GeneralApplicationConstants;

    public class ControllerAuthorizationTests
    {
        [TestCase(typeof(BaseAdminController), AdminRoleName)]
        [TestCase(typeof(BaseCompanyController), CompanyRoleName)]
        public void RoleProtectedBaseControllers_ShouldRequireExpectedRole(Type controllerType, string expectedRole)
        {
            var authorizeAttribute = controllerType
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Cast<AuthorizeAttribute>()
                .Single();

            authorizeAttribute.Roles.Should().Be(expectedRole);
        }

        [Test]
        public void ManageBaseController_ShouldRequireAuthenticatedUser()
        {
            bool hasAuthorizeAttribute = typeof(BaseManageController)
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Any();

            hasAuthorizeAttribute.Should().BeTrue();
        }

        [Test]
        public void CompanyTechnologyController_ShouldUseCompanyAuthorizationBase()
        {
            typeof(Web.Areas.Company.Controllers.TechnologyController)
                .Should()
                .BeDerivedFrom<BaseCompanyController>();
        }
    }
}
