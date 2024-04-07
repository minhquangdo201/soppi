using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace soppi.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {

        return View();
    }
}