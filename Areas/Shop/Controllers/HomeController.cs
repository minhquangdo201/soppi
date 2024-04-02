using Microsoft.AspNetCore.Mvc;

namespace soppi.Areas.Shop.Controllers {
    [Area("Shop")]
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}