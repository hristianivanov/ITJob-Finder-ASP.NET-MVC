namespace DevHunter.Controller.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Web.Areas.Admin.Controllers;
    using Web.Areas.Company.Controllers;
    using Web.Areas.Manage.Controllers;

    using static Common.GeneralApplicationConstants;

    public class AuthorizationControllerTests
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

        [TestCase(typeof(BaseAdminController), "Admin")]
        [TestCase(typeof(BaseCompanyController), "Company")]
        [TestCase(typeof(BaseManageController), "Manage")]
        public void BaseControllers_ShouldHaveCorrectAreaAttribute(Type controllerType, string expectedArea)
        {
            var areaAttr = controllerType
                .GetCustomAttributes(typeof(AreaAttribute), true)
                .Cast<AreaAttribute>()
                .SingleOrDefault();

            areaAttr.Should().NotBeNull($"{controllerType.Name} should declare [Area]");
            areaAttr!.RouteValue.Should().Be(expectedArea);
        }

        [TestCase(typeof(Web.Areas.Company.Controllers.JobOfferController))]
        [TestCase(typeof(Web.Areas.Company.Controllers.CompanyController))]
        public void CompanyAreaControllers_ShouldDeriveFromBaseCompanyController(Type controllerType)
        {
            controllerType.Should().BeDerivedFrom<BaseCompanyController>();
        }

        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController))]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController))]
        public void AdminAreaControllers_ShouldDeriveFromBaseAdminController(Type controllerType)
        {
            controllerType.Should().BeDerivedFrom<BaseAdminController>();
        }

        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController), "Add")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController), "Edit")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController), "Delete")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController), "Add")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController), "Edit")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController), "Delete")]
        [TestCase(typeof(Web.Areas.Company.Controllers.JobOfferController), "Add")]
        [TestCase(typeof(Web.Areas.Company.Controllers.JobOfferController), "Edit")]
        [TestCase(typeof(Web.Areas.Company.Controllers.JobOfferController), "Delete")]
        public void WriteActions_ShouldHaveAtLeastOneHttpPostOverload(
            Type controllerType, string actionName)
        {
            bool hasPostOverload = controllerType
                .GetMethods()
                .Where(m => m.Name == actionName)
                .Any(m => m.GetCustomAttributes(typeof(HttpPostAttribute), true).Any());

            hasPostOverload.Should().BeTrue(
                $"{controllerType.Name}.{actionName} should have an [HttpPost] overload");
        }

        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController), "Edit")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.TechnologyController), "Add")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController), "Edit")]
        [TestCase(typeof(Web.Areas.Admin.Controllers.DevelopmentController), "Add")]
        public void ReadActions_ShouldHaveAtLeastOneHttpGetOverload(
            Type controllerType, string actionName)
        {
            bool hasGetOverload = controllerType
                .GetMethods()
                .Where(m => m.Name == actionName)
                .Any(m => m.GetCustomAttributes(typeof(HttpGetAttribute), true).Any());

            hasGetOverload.Should().BeTrue(
                $"{controllerType.Name}.{actionName} should have an [HttpGet] overload");
        }
    }
}
