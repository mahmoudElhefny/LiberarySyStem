using Library.ViewModel.Account;
using Microsoft.AspNetCore.Identity;

namespace Library.Repositories.Account
{
    public interface IAccountRepository
    {
         Task<bool> Register(RegisterVM model);
    }
}
