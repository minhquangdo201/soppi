using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Models.ViewModel;

namespace soppi.Interfaces {
    public interface IOrderService {
        Task<IActionResult> CreateOrder(OrderViewModel orderViewModel);
        Task<List<Order>> GetAllOrdersByUser();
        Task<List<Order>> GetAllOrdersByShop();
        Task<IActionResult> DeleteOrder(Guid id);
        Task<IActionResult> ChangeStatus(OrderStatusViewModel orderStatusViewModel);
    }
}