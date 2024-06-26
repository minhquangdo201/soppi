using Microsoft.AspNetCore.Mvc;
using soppi.Models;
using soppi.Models.ViewModel;
using soppi.Interfaces;

namespace soppi.Controllers {
    public class CategoryController : Controller {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryDropDown() {
            var categories = await _categoryService.GetAll();
            return PartialView("_CategoryDropDown", categories);
        }

        public IActionResult Index() {
            var categories = _categoryService.GetAll().Result;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category) {
            await _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryProducts(int id, string searchStr) {
            var products = await _categoryService.GetProductsByCategory(id);
            if(string.IsNullOrEmpty(searchStr)) {
                return View(products);
            }
            if (!string.IsNullOrEmpty(searchStr)) {
                products = products.Where(p => p.ProductName.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            return View(products);
        }
    }
}