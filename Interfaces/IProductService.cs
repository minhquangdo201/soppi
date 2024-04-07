using soppi.Models.ViewModel;
using soppi.Models;
using Microsoft.AspNetCore.Mvc;
namespace soppi.Interfaces;
public interface IProductService {
    Task<List<ProductViewModel>> GetAll();

    Task<Product> AddProduct(ProductViewModel productViewModel);
    Task<ProductViewModel> GetProductById(Guid id);
    Task<List<ProductViewModel>> GetProductByShop(string id);
    Task<Product> AddProductToShop(ProductViewModel productViewModel);
    Task<IActionResult> DeleteProduct(Guid id);
    Task<IActionResult> UpdateProduct(ProductViewModel productViewModel);
}