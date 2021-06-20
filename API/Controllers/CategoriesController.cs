using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
