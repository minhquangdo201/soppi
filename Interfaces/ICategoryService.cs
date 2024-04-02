using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Models.ViewModel;
namespace soppi.Interfaces;
public interface ICategoryService {
    Task<List<Category>> GetAll();

    Task<Category> AddCategory(CategoryViewModel category);

    Task<List<ProductViewModel>> GetProductsByCategory(int id);

    Task<IActionResult> CreateCategory(Category category);
}