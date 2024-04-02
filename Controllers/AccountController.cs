using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Interfaces;
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(SignIn model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.Login(model);
            if (result != null)
            {
                if (result == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (result == "Shop")
                {
                    return RedirectToAction("Index", "Home", new { area = "Shop" });
                }
                else if (result == "User")
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUp model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.Register(model);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Account");
            }
            ModelState.AddModelError(string.Empty, "Invalid Registration Attempt");
        }
        return View(model);
    }

    public async Task<IActionResult> LogOut()
    {
        var result = await _accountService.LogOut();
        if (result is OkResult)
        {
            return RedirectToAction("SignIn", "Account");
        }
        return RedirectToAction("Index", "Home");
    }

}