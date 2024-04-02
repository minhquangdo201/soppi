using Microsoft.AspNetCore.Mvc;
namespace soppi.Areas.Admin.Controllers;


[Area("Admin")]
public class HomeController : Controller {
    public IActionResult Index() {
        
        return View();
    }

    public IActionResult Secret() {
        return View();
    }
}