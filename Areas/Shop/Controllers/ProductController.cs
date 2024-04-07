using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soppi.Data;
using soppi.Interfaces;
using soppi.Models.ViewModel;

namespace soppi.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Authorize(Roles = "Shop")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotyfService _notyf;

        public ProductController(IProductService productService, ICategoryService categoryService, SignInManager<ApplicationUser> signInManager, INotyfService notyf)
        {
            _notyf = notyf;
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

        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await _productService.GetProductById(id);
            var categories = await _categoryService.GetAll();
            ViewBag.Product = product;
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel product)
        {
            var rs = await _productService.UpdateProduct(product);
            if (rs is OkResult)
            {
                _notyf.Success("Cập nhật thành công!");
                return RedirectToAction("Index", "Product", new { area = "Shop" });
            }
            _notyf.Error("Cập nhật không thành công!");
            return RedirectToAction("Detail", "Product", new { id = product.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rs = await _productService.DeleteProduct(id);
            if (rs is OkResult)
            {
                _notyf.Success("Xóa sản phẩm thành công!");
                return RedirectToAction("Index", "Product", new { area = "Shop" });
            }
            _notyf.Error("Xóa sản phẩm không thành công!");
            return RedirectToAction("Detail", "Product", new { id = id });
        }
    }

}