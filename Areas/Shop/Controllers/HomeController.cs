using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models;

namespace soppi.Areas.Shop.Controllers {
    [Area("Shop")]
    [Authorize(Roles = "Shop")]
    public class HomeController : Controller {
        private readonly IOrderService _orderService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IProductService _productService;

        public HomeController(ApplicationDbContext context, IOrderService orderService, IProductService productService, SignInManager<ApplicationUser> signInManager) {
            _productService = productService;
            _orderService = orderService;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index() {
            var product = await _productService.GetProductByShop(_signInManager.UserManager.GetUserId(User));
            var order =  await _orderService.GetAllOrdersByShop();
            ViewBag.ProductCount = product.Count();
            ViewBag.OrderCount = order.Count();
            return View();
        }
    }
}