using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;
using soppi.Models;

namespace soppi.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var rs = await _categoryService.CreateCategory(category);
            if(rs is OkResult)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return new BadRequestResult();
        }
    }
}