using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
namespace soppi.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICategoryService _categoryService;

    public HomeController(UserManager<ApplicationUser> userManager, ICategoryService categoryService)
    {
        _userManager = userManager;
        _categoryService = categoryService;
    }
    public async Task<IActionResult> Index()
    {
        var usersCount = await _userManager.GetUsersInRoleAsync("User");
        var shopsCount = await _userManager.GetUsersInRoleAsync("Shop");
        var adminsCount = await _userManager.GetUsersInRoleAsync("Admin");
        ViewBag.UsersCount = usersCount.Count + shopsCount.Count + adminsCount.Count; 
        var categories = await _categoryService.GetAll();
        ViewBag.CategoryCount = categories.Count();
        return View();
    }
}