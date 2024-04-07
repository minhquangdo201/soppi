using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                if(o.Quantity == 0){
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
                product.StockQuantity = product.StockQuantity - o.Quantity;
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

        public async Task<List<Order>> GetAllOrdersByShop()
        {
            var shopId =  _userManager.GetUserId(_signInManager.Context.User);
            var orders = await _context.Orders.Include(o => o.Product).Include(o => o.User).Where(o => o.Product.User.Id == shopId).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

        public async Task<List<Order>> GetAllOrdersByUser()
        {
            var userId = _userManager.GetUserId(_signInManager.Context.User);
            var orders = await _context.Orders.Include(o => o.Product).Include(o => o.Product.User).Where(o => o.User.Id == userId).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return null;
            }
            order.Product.StockQuantity = order.Product.StockQuantity + order.Quantity;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> ChangeStatus(OrderStatusViewModel o)
        {
            var order = await _context.Orders.FindAsync(o.Id);
            if (order == null)
            {
                return null;
            }
            order.Status = o.Status;
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var order =  await _context.Orders.Include(o => o.Product).Include(o => o.User).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return null;
            }
            return order;
        }



        public async Task<IActionResult> UpdateOrderStatus(Guid id, string status){
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            order.Status = status;
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}