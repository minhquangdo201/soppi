using Microsoft.AspNetCore.Mvc;
using soppi.Models.ViewModel;
using soppi.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;

public class ProductController : Controller {
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly INotyfService _notyf;

    public ProductController(IProductService productService, ICategoryService categoryService, INotyfService notyf) {
        _productService = productService;
        _categoryService = categoryService;
        _notyf = notyf;
    }

    public async Task<IActionResult> Index() {
        var products = await _productService.GetAll();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Add() {
        var categories = await _categoryService.GetAll();
        ViewBag.Categories = categories;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(ProductViewModel productViewModel) {
        await _productService.AddProduct(productViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid id){
        var product = await _productService.GetProductById(id);
        ViewBag.Product = product;
        return View();
    }
}