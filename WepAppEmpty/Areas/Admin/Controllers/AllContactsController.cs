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
using WepAppEmpty.Infracstructures.Sessions;

namespace WepAppEmpty.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminRequired]
    public class AllContactsController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IContactRepository _contactRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AllContactsController(IContactRepository contactService, ICategoryRepository categoryService, ISessionManager sessionManager)
        {
            _contactRepository = contactService;
            _categoryRepository = categoryService;
            _sessionManager = sessionManager;
        }
        // GET: AllContactsController
        public ActionResult Index()
        {

            AllContacts allContacts = new AllContacts();

            allContacts.Contacts = _contactRepository.Get();

            //Dictionary<Category, List<Contact>> Dictionnary = new Dictionary<Category, List<Contact>>();
            foreach(Category c in _categoryRepository.Get())
            {
                allContacts.Dictionnary.Add(c, _contactRepository.GetByCategory(c.Id).ToList());
            }
            //var Categories = _categoryRepository.Get();
            //var contacts = new AllContacts
            //{
            //    Categories = _categoryRepository.Get(),
            //    Personnels = _contactRepository.GetPersonnalCategory(),
            //    Professionnal = _contactRepository.GetProfessionnalCategory(),
            //    ContactsAll = _contactRepository.Get()
            //};
            //var contacts = _contactRepository.Get();

            return View(allContacts);
        }

        // GET: AllContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
