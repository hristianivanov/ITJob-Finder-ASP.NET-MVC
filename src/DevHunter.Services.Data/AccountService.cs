namespace DevHunter.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using DevHunter.Data;
    using DevHunter.Data.Models;

    using Interfaces;
    using Web.ViewModels.User;

    using static DevHunter.Common.GeneralApplicationConstants;

    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICompanyService companyService;
        private readonly DevHunterDbContext dbContext;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            ICompanyService companyService,
            DevHunterDbContext dbContext)
        {
            this.userManager = userManager;
            this.companyService = companyService;
            this.dbContext = dbContext;
        }

        public async Task<IdentityResult> RegisterCompanyAsync(CompanyRegisterFormModel model)
        {
            bool companyExists = await this.companyService.ExistsByNameAsync(model.Name);
            if (companyExists)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = nameof(model.Name),
                    Description = "Company with this name already exists!"
                });
            }

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            bool isRelational = this.dbContext.Database.IsRelational();
            IDbContextTransaction? transaction = isRelational
                ? await this.dbContext.Database.BeginTransactionAsync()
                : null;

            try
            {
                IdentityResult createResult = await this.userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                    return createResult;

                IdentityResult roleResult = await this.userManager.AddToRoleAsync(user, CompanyRoleName);
                if (!roleResult.Succeeded)
                {
                    if (transaction != null) await transaction.RollbackAsync();
                    return roleResult;
                }

                await this.companyService.AddAsync(model, user.Id);

                if (transaction != null) await transaction.CommitAsync();

                return IdentityResult.Success;
            }
            catch
            {
                if (transaction != null) await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaction != null) await transaction.DisposeAsync();
            }
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterFormModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            return await this.userManager.CreateAsync(user, model.Password);
        }
    }
}
