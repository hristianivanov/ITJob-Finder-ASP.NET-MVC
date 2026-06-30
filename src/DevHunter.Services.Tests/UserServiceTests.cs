namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Interfaces;

    using DevHunter.Data;

    using Web.ViewModels.User;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    [TestFixture]
    public class UserServiceTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;
        private IUserService userService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            userService = new UserService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        // ── AllAsync ────────────────────────────────────────────────────────────

        [Test]
        public async Task AllAsync_ShouldReturnAllUsers()
        {
            var dbUsers = await dbContext.Users.ToListAsync();

            var result = await userService.AllAsync();

            result.Should().NotBeNullOrEmpty()
                .And.HaveSameCount(dbUsers)
                .And.AllBeOfType<UserViewModel>();
        }

        [Test]
        public async Task AllAsync_ShouldMapUserIdCorrectly()
        {
            var dbUser = await dbContext.Users.FirstAsync();

            var result = await userService.AllAsync();

            result.Should().Contain(vm => vm.Id == dbUser.Id.ToString());
        }

        [Test]
        public async Task AllAsync_ShouldSetIsCompanyTrueForUserWithCompany()
        {
            var companyUser = await dbContext.Users.FirstAsync(u => u.Companies.Any());

            var result = await userService.AllAsync();

            result.First(vm => vm.Id == companyUser.Id.ToString())
                .IsCompany.Should().BeTrue();
        }

        [Test]
        public async Task AllAsync_ShouldSetIsCompanyFalseForRegularUser()
        {
            var regularUser = await dbContext.Users.FirstAsync(u => !u.Companies.Any());

            var result = await userService.AllAsync();

            result.First(vm => vm.Id == regularUser.Id.ToString())
                .IsCompany.Should().BeFalse();
        }

        [Test]
        public async Task AllAsync_ShouldSetFullNameCorrectly()
        {
            var dbUser = await dbContext.Users.FirstAsync();

            var result = await userService.AllAsync();

            var vm = result.First(u => u.Id == dbUser.Id.ToString());
            vm.FullName.Should().Be($"{dbUser.FirstName} {dbUser.LastName}");
        }

        [Test]
        public async Task AllAsync_ShouldSetEmailCorrectly()
        {
            var dbUser = await dbContext.Users.FirstAsync(u => u.Email != null);

            var result = await userService.AllAsync();

            var vm = result.First(u => u.Id == dbUser.Id.ToString());
            vm.Email.Should().Be(dbUser.Email);
        }

        // ── GetUserByIdAsync ────────────────────────────────────────────────────

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnCorrectUser()
        {
            var dbUser = await dbContext.Users.FirstAsync();

            var result = await userService.GetUserByIdAsync(dbUser.Id.ToString());

            result.Should().NotBeNull().And.BeOfType<UserViewModel>();
            result.Id.Should().Be(dbUser.Id.ToString());
            result.Email.Should().Be(dbUser.Email ?? string.Empty);
            result.FullName.Should().Be($"{dbUser.FirstName} {dbUser.LastName}");
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldSetIsCompanyCorrectly()
        {
            var companyUser = await dbContext.Users.FirstAsync(u => u.Companies.Any());
            var regularUser = await dbContext.Users.FirstAsync(u => !u.Companies.Any());

            var companyVm = await userService.GetUserByIdAsync(companyUser.Id.ToString());
            var regularVm = await userService.GetUserByIdAsync(regularUser.Id.ToString());

            companyVm.IsCompany.Should().BeTrue();
            regularVm.IsCompany.Should().BeFalse();
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldThrowForNonExistingUser()
        {
            var act = async () => await userService.GetUserByIdAsync(Guid.NewGuid().ToString());

            await act.Should().ThrowAsync<Exception>();
        }
    }
}
