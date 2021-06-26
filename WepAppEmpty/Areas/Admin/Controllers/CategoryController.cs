using Microsoft.AspNetCore.Mvc;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Areas.Admin.Infracstructures.Security;
using WepAppEmpty.Areas.Admin.Models.Forms;

namespace WepAppEmpty.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminRequired]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<DisplayCategory> categories = _categoryRepository.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name });
            
            return View(categories);
        }
    }
}
