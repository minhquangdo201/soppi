using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Models.ViewModel;

namespace soppi.Interfaces {
    public interface IOrderService {
        Task<IActionResult> CreateOrder(OrderViewModel orderViewModel);
        Task<List<Order>> GetAllOrdersByUser(string userId);
        Task<List<Order>> GetAllOrdersByShop(string shopId);
    }
}