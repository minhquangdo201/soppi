using Microsoft.AspNetCore.Mvc;
using soppi.Interfaces;

public class CategoryViewComponent : ViewComponent {
    private readonly ICategoryService _categoryService;

    public CategoryViewComponent(ICategoryService categoryService) {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        var categories = await _categoryService.GetAll();
        return View(categories);
    }
}