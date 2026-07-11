namespace DevHunter.Services.Data.Interfaces
{
    using Microsoft.AspNetCore.Identity;

    using Web.ViewModels.User;

    public interface IAccountService
    {
        Task<IdentityResult> RegisterCompanyAsync(CompanyRegisterFormModel model);
        Task<IdentityResult> RegisterUserAsync(RegisterFormModel model);
    }
}
