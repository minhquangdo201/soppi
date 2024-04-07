using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Interfaces;

namespace soppi.Controllers;


public class HomeController : Controller
{

    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;



    public HomeController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var products = await _productService.GetAll();

        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.ProductName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        ViewBag.Products = products;
        return View();
    }

}
