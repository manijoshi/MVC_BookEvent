using BookEventApplication.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookEventApplication.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PassWordSignInAsync(LogInModel logInModel);

        Task SignOutAsync();
    }
}