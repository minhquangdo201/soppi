using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models;
using soppi.Models.ViewModel;

namespace soppi.Services;
public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll()
    {

        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> AddCategory(CategoryViewModel category)
    {
        var c = new Category
        {
            CategoryName = category.CategoryName
        };
        await _context.Categories.AddAsync(c);
        await _context.SaveChangesAsync();
        return c;
    }

    public async Task<List<ProductViewModel>> GetProductsByCategory(int id)
    {
        var products = new List<ProductViewModel>();
        products = await _context.Products.Where(p => p.Category.Id == id).Select(
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

    public async Task<IActionResult> CreateCategory(Category category){
        var listCats = await _context.Categories.ToListAsync();
        foreach (var cat in listCats)
        {
            if (cat.CategoryName == category.CategoryName)
            {
                return new BadRequestResult();
            }
        }
        var len = await _context.Categories.CountAsync();
        var id = len + 1;
        category.Id = id;
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return new OkResult();
    }
}