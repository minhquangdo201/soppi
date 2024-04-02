using Microsoft.EntityFrameworkCore;
using soppi.Models.ViewModel;
using soppi.Models;
using soppi.Data;
using soppi.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace soppi.Services;
public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProductService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task<List<ProductViewModel>> GetAll()
    {
        var products = new List<ProductViewModel>();
        products = await _context.Products.Select(
            item => new ProductViewModel
            {
                Id = item.Id,
                ProductName = item.ProductName,
                CategoryName = item.Category.CategoryName,
                Price = item.Price,
                StockQuantity = item.StockQuantity,
                Description = item.Description,
                Image = item.Image
            }).ToListAsync();
        return products;
    }

    public async Task<Product> AddProduct(ProductViewModel productViewModel)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == productViewModel.CategoryName);
        Console.WriteLine(productViewModel.CategoryName);
        if (category == null)
        {
            throw new Exception(productViewModel.CategoryName + " not found!");
        }

        var product = new Product
        {
            ProductName = productViewModel.ProductName,
            Category = category,
            Price = productViewModel.Price,
            StockQuantity = productViewModel.StockQuantity,
            Description = productViewModel.Description,
            Image = productViewModel.Image,
        };
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<ProductViewModel> GetProductById(Guid id)
    {
        var product = await _context.Products
                                .Include(p => p.Category) // Include Category for accessing CategoryName
                                .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new Exception("Product not found!");
        }

        var productViewModel = new ProductViewModel
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CategoryName = product.Category.CategoryName,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Description = product.Description,
            Image = product.Image
        };
        return productViewModel;
    }

    public async Task<List<ProductViewModel>> GetProductByShop(string id)
    {
        var products = new List<ProductViewModel>();
        products = await _context.Products.Where(p => p.User.Id == id).Select(
            item => new ProductViewModel
            {
                Id = item.Id,
                ProductName = item.ProductName,
                CategoryName = item.Category.CategoryName,
                Price = item.Price,
                StockQuantity = item.StockQuantity,
                Description = item.Description,
                Image = item.Image
            }).ToListAsync();
        return products;
    }

    public async Task<Product> AddProductToShop(ProductViewModel productViewModel){
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == productViewModel.CategoryName);
        if (category == null)
        {
            throw new Exception(productViewModel.CategoryName + " not found!");
        }

        var product = new Product
        {
            ProductName = productViewModel.ProductName,
            Category = category,
            Price = productViewModel.Price,
            StockQuantity = productViewModel.StockQuantity,
            Description = productViewModel.Description,
            Image = productViewModel.Image,
            User = await _userManager.FindByIdAsync(productViewModel.UserId)
        };
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }
}

