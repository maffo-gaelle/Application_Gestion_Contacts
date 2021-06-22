using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Services;

namespace WepAppEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactService _contactService;

        public HomeController(ContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            AllContacts vm = new AllContacts();

            vm.Personnels = _contactService.GetPersonnalCategory();
            vm.Professionnal = _contactService.GetProfessionnalCategory();
            vm.Autres = _contactService.GetOthersCategory();
            vm.GetAllContacts = _contactService.Get();
            vm.cpt = 1;

            return View(vm);
        }
    }
}
