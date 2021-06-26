using Microsoft.AspNetCore.Mvc;
using Model.Client.Repositories;
using Model.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;

namespace WepAppEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public HomeController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            //AllContacts vm = new()
            //{
            //    Personnels = _contactRepository.GetPersonnalCategory(),
            //    Professionnal = _contactRepository.GetProfessionnalCategory(),
            //    Autres = _contactRepository.GetOthersCategory(),
            //    GetAllContacts = _contactRepository.Get(),
            //    cpt = 1
            //};

            return View();
        }
    }
}
