using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;
using soppi.Models.ViewModel;
namespace soppi.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AccountController : Controller {
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService) {
        _accountService = accountService;
    }
    public async Task<IActionResult> Index() {
        var users = await _accountService.GetAllUser();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(string id){
        var user = await _accountService.GetUserById(id);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AccountViewModel model){
        var rs = await _accountService.UpdateUser(model);
        if(rs is OkResult){
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }
        return RedirectToAction("Index", "Account");
    }

}