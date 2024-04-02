using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models.ViewModel;

namespace soppi.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProductController(IProductService productService, ICategoryService categoryService, SignInManager<ApplicationUser> signInManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var id = _signInManager.UserManager.GetUserId(User);
            var products = await _productService.GetProductByShop(id);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            var rs = await _productService.AddProductToShop(product);
            if (rs != null)
            {
                return RedirectToAction("Index", "Product", new { area = "Shop" });
            }
            return RedirectToAction("Add", "Product");
        }
    }

}