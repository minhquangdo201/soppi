using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models;
using soppi.Models.ViewModel;

namespace soppi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly INotyfService _notyf;

        public OrderController(IOrderService orderService, INotyfService notyf, SignInManager<ApplicationUser> signInManager)
        {
            _orderService = orderService;
            _notyf = notyf;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersByUser();
            return View(orders);

        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderViewModel order)
        {
            var rs = await _orderService.CreateOrder(order);
            if (rs is OkResult)
            {
                _notyf.Success("Đặt hàng thành công!");
                return RedirectToAction("Detail", "Product", new { id = order.ProductId });
            }
            _notyf.Error("Đặt hàng không thành công!");
            return RedirectToAction("Detail", "Product", new { id = order.ProductId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rs = await _orderService.DeleteOrder(id);
            if (rs is OkResult)
            {
                _notyf.Success("Xóa đơn hàng thành công!");
                return RedirectToAction("Index");
            }
            _notyf.Error("Xóa đơn hàng không thành công!");
            return RedirectToAction("Index");
        }
    }
}
