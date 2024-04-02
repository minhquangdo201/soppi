using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Models;
using soppi.Models.ViewModel;
namespace soppi.Interfaces;
public interface IAccountService
{
    Task<IdentityResult> Register(SignUp model);
    Task<string> Login(SignIn model);
    Task<IActionResult> LogOut();

    Task<List<AccountViewModel>> GetAllUser();
    Task<AccountViewModel> GetUserById(string id);
    Task<IActionResult> UpdateUser(AccountViewModel accountViewModel);
}