using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;
using soppi.Models.ViewModel;
namespace soppi.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly INotyfService  _notyf;
    public AccountController(IAccountService accountService, INotyfService notyf)
    {
        _accountService = accountService;
        _notyf = notyf;
    }
    public async Task<IActionResult> Index()
    {
        var users = await _accountService.GetAllUser();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(string id)
    {
        var user = await _accountService.GetUserById(id);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AccountViewModel model)
    {
        var rs = await _accountService.UpdateUser(model);
        if (ModelState.IsValid)
        {
            if (rs is OkResult)
            {
                _notyf.Success("Cập nhật thành công!");
                return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            _notyf.Error("Cập nhật không thành công!");
        }

        return RedirectToAction("Index", "Account");
    }

}