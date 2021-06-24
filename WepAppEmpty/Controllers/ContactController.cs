using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Client;
using Model.Client.Data;
using Model.Client.Repositories;
using Model.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Forms;
using WepAppEmpty.Models.Sessions;

namespace WepAppEmpty.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IContactRepository _contactRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ContactController(IContactRepository contactService, ICategoryRepository categoryService, ISessionManager sessionManager)
        {
            _contactRepository = contactService;
            _categoryRepository = categoryService;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            var contacts = _contactRepository.Get();

            return View(contacts);
        }
    
        public IActionResult Details(int id)
        {

            return View(_contactRepository.Get(id));
        }
        //J'ai besoin de deux methode create, la première c'est en get pour recuperer mon formulaire au server et l'afficher
        //La deuxième, c'est pour envoyer mon formulaire avec les données remplies. Elle contient l'attribut httpPost
        public IActionResult Create(int id)
        {
            if (_sessionManager.User == null)
                return RedirectToAction("Login", "Auth");

            CreateContactForm form = new CreateContactForm();

            //On ne peut pas envoyé directement les catégorie qu'on récupère ans la base de données à la vue
            //puisque ce que la vue doit affichée, ce sont des selectedItems
            form.Categories = GetCategories();

            if (id != 0)
            {
                Contact contact = _contactRepository.Get(id);

                if (contact is null)
                    return RedirectToAction("Index");

                //EditContactForm form = new EditContactForm();
                form.Id = contact.Id;
                form.LastName = contact.LastName;
                form.FirstName = contact.FirstName;
                form.Email = contact.Email;
                form.CategoryId = contact.CategoryId;
            }

            return View(form);
        }

        //Les paramètres de la methode create en post doivent avoir les mêmes nom que la valeur de name dans le formulaire independamment de la casse
        [HttpPost]
        public IActionResult Create(CreateContactForm form)
        {

            if (_sessionManager.User == null)
                return RedirectToAction("Login", "Auth");
            //ValidationContext validationContext = new ValidationContext(form);
            //if (!ModelState.IsValid && form.Validate(validationContext).Count() != 0)
            if (!ModelState.IsValid)
            {
                form.Categories = GetCategories();
                return View(form);
            }

            if(form.Id == 0)
            {
                Contact newcontact = new Contact(form.LastName, form.FirstName, form.Email, form.CategoryId, _sessionManager.User.Id);

                _contactRepository.Insert(newcontact);
            } 
            else
            {
                Contact contact = _contactRepository.Get(form.Id);
                contact.LastName = form.LastName;
                contact.FirstName = form.FirstName;
                if (contact.Email != form.Email)
                {
                    contact.Email = form.Email;
                }
                contact.CategoryId = form.CategoryId;

                _contactRepository.Update(form.Id, contact);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Contact contact = _contactRepository.Get(id);

            if (contact is null)
                return RedirectToAction("Index");
            //_contactService.DeleteContact(id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _contactRepository.Delete(id);

            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            IEnumerable<Category> categories = _categoryRepository.Get();

            //Je récupère mes catégories de ma base de données que je transforme en selected items
            //qui seront envoyé à mon formulaire dans le select
            return categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
        }
    }
}










































//public IActionResult Edit(int id)
//{
//    Contact contact = _contactService.Get(id);
//    if(contact is null)
//        
//    EditContactForm form = new EditContactForm() {
    //    Id = contact.Id;
    //    LastName = contact.LastName;
    //    FirstName = contact.FirstName;
    //    Email = contact.Email;
    //    CategoryId = contact.CategoryId;
    //    Categories = GetCategories();
//    };
//    

//    return View(form);
//}

//[HttpPost]
//public IActionResult Edit(EditContactForm form)
//{
//    if (!ModelState.IsValid)
//    {
//        form.Categories = GetCategories();
//        return View(form);
//    }

//    return RedirectToAction("Index");
//}
