using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models;
using soppi.Models.ViewModel;
namespace soppi.Services;
public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;


    public AccountService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task<string> Login(SignIn model)

    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password!, model.RememberMe, false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return "Admin";
                }
                else if (await _userManager.IsInRoleAsync(user, "Shop"))
                {
                    return "Shop";
                }
                else
                {
                    return "User";
                }
            }

        }
        return null;

    }

    public async Task<IdentityResult> Register(SignUp model)
    {
        var user = new ApplicationUser
        {
            Email = model.Email,
            UserName = model.UserName,
            Address = model.Address,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        await _userManager.AddToRoleAsync(user, model.Role);
        return result;
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return new OkResult();
    }

    public async Task<List<AccountViewModel>> GetAllUser()
    {
        var users = await _userManager.Users.ToListAsync();
        var userViewModels = new List<AccountViewModel>();
        foreach (var user in users)
        {

            var userViewModel = new AccountViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()

            };
            userViewModels.Add(userViewModel);
        }
        return userViewModels;
    }

    public async Task<AccountViewModel> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        var userViewModel = new AccountViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Name = user.Name,
            Address = user.Address,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
        };
        return userViewModel;
    }

    public async Task<IActionResult> UpdateUser(AccountViewModel model)
    {
        var user = await _userManager.FindByIdAsync(model.Id);
        user.UserName = model.UserName;
        user.Name = model.Name;
        user.Address = model.Address;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        await _userManager.UpdateAsync(user);
        await _userManager.RemoveFromRoleAsync(user, model.Role);
        await _userManager.AddToRoleAsync(user, model.Role);
        return new OkResult();
    }
}