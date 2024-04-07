using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace soppi.Areas.Shop.Controllers {
    [Area("Shop")]
    [Authorize(Roles = "Shop")]
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}