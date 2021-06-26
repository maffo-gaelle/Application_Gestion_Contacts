using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Client.Data;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Areas.Admin.Infracstructures.Security;
using WepAppEmpty.Areas.Admin.Models;
using WepAppEmpty.Areas.Admin.Models.Forms;

namespace WepAppEmpty.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminRequired]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContactRepository _contactRepository;

        public CategoryController(ICategoryRepository categoryRepository, IContactRepository contactRepository)
        {
            _categoryRepository = categoryRepository;
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<DisplayCategory> categories = _categoryRepository.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name });
            
            return View(categories);
        }

        public IActionResult Create(int Id)
        {
            CreateCategoryForm form = new CreateCategoryForm();
            if(Id != 0)
            {
                Category category = _categoryRepository.Get(Id);
                form.Id = Id;
                form.Name = category.Name;
            } 

            return View(form);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if (form.Id != 0)
            {
                Category category = _categoryRepository.Get(form.Id);
                category.Name = form.Name;

                _categoryRepository.Update(form.Id, category);

            } else
            {
                Category newCategory = new Category(form.Name);

                _categoryRepository.Insert(newCategory);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            CategoryStatut categoryStatut = new CategoryStatut();

            categoryStatut.category = _categoryRepository.Get(id);

            categoryStatut.ContactsByCategory = _contactRepository.GetByCategory(id);
            
            return View(categoryStatut);
        }
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _categoryRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
