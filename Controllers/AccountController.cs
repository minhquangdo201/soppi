using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using soppi.Data;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly INotyfService _notyf;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(IAccountService accountService, INotyfService notyf, SignInManager<ApplicationUser> signInManager)
    {
        _accountService = accountService;
        _notyf = notyf;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            else if (User.IsInRole("Shop"))
                return RedirectToAction("Index", "Home", new { area = "Shop" });
            return RedirectToAction("Index", "Home");
        }
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
                    _notyf.Success("Chào mừng bạn đến với trang dành cho Quản trị viên!", 4);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (result == "Shop")
                {
                    _notyf.Success("Chào mừng bạn đến với trang dành cho Người bán hàng!", 4);
                    return RedirectToAction("Index", "Home", new { area = "Shop" });
                }
                else if (result == "User")
                {
                    _notyf.Success("Đăng nhập thành công!", 4);
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError(string.Empty, "Tên tài khoản hoặc mật khẩu không đúng!");
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
                _notyf.Success("Đăng ký thành công!", 4);
                return RedirectToAction("SignIn", "Account");
            }
            ModelState.AddModelError(string.Empty, "Tên tài khoản đã tồn tại!");
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