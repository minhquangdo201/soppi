using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;
using soppi.Models;

namespace soppi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly INotyfService _notyf;
        public CategoryController(ICategoryService categoryService, INotyfService notyf)
        {
            _categoryService = categoryService;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
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
                _notyf.Success("Thêm danh mục thành công!");
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            _notyf.Error("Tên danh mục đã tồn tại!");
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _categoryService.DeleteCategory(id);
            if(rs is OkResult)
            {   
                _notyf.Success("Xóa danh mục thành công!");
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            _notyf.Error("Xóa danh mục không thành công!");
            return new BadRequestResult();
        }
    }
}