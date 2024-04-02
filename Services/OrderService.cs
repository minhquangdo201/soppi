using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models;
using soppi.Models.ViewModel;

namespace soppi.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> CreateOrder(OrderViewModel o)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(o.UserId);
                var product = await _context.Products.FindAsync(o.ProductId);
                if (user == null || product == null)
                {
                    return null;
                }
                var order = new Order
                {
                    User = user,
                    OrderDate = DateTime.Now,
                    ShippingAddress = user.Address,
                    Product = product,
                    Quantity = o.Quantity,
                    TotalPrice = product.Price * o.Quantity,
                    Status = "Pending"
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Task<List<Order>> GetAllOrdersByShop(string shopId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}