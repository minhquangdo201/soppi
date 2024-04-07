using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;

namespace soppi.Areas.Shop.Controllers {
    [Area("Shop")]
    [Authorize (Roles = "Shop")]
    public class OrderController : Controller {
        private readonly IOrderService _orderService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotyfService _notyf;

        public OrderController(IOrderService orderService, INotyfService notyf, SignInManager<ApplicationUser> signInManager) {
            _orderService = orderService;
            _notyf = notyf;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index() {
            var orders = await _orderService.GetAllOrdersByShop();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Update(){
            return View();
        }
    }
}