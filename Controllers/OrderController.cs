using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;
using soppi.Models.ViewModel;

namespace soppi.Controllers {
    public class OrderController : Controller {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }
        public IActionResult Index() {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Add(OrderViewModel order) {
            var rs = await _orderService.CreateOrder(order);
            if(rs is OkResult) {
                return RedirectToAction("Detail", "Product", new { id = order.ProductId });
            }
            return new BadRequestResult();
        }
    }
}