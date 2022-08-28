using Library.Models;
using Library.ViewModel.Account;
using Microsoft.AspNetCore.Identity;

namespace Library.Repositories.Account
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> Register(RegisterVM model)
        {
            var user = new ApplicationUser();
            user.UserName = model.UserName;
            user.Address = model.Address;
            user.PhoneNumber = model.Phone;
            user.BirthDate = model.BirthDate;
            user.PasswordHash = model.Password;
            user.Gender = model.Gender;
            user.Email = model.Email;
            IdentityResult result = await userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
                return true;
            else
                return false;
        }
    }
}
