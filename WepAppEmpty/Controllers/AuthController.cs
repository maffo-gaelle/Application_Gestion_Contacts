using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Forms;
using WepAppEmpty.Services;

namespace WepAppEmpty.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            LoginForm form = new LoginForm();

            return View(form);
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if(!ModelState.IsValid)
                return View(form);

            User user = _userService.Get(form.Email);


            if (user == null)
            {
                ViewBag.ErrorEmail = ("Cet email n'existe pas");
                return View(form);
            }

            if (user.Passwd != form.Passwd)
            {
                ViewBag.ErrorPasswd = ("Le mot de passe est incorrect");
                return View(form);
            }

            HttpContext.Session.SetInt32("id", user.id);
            ViewBag.Id = HttpContext.Session.GetInt32(user.id.ToString());
            ViewBag.Nom = HttpContext.Session.GetString(user.LastName);
            ViewBag.Email = HttpContext.Session.GetString(user.Email);



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            CreateUserForm form = new CreateUserForm();

            return View(form);
        }

        [HttpPost]
        public IActionResult Signup(CreateUserForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User newUser = new User()
            {
                LastName = form.LastName,
                FirstName = form.FirstName,
                Email = form.Email,
                BirthDate = form.BirthDate,
                Passwd = form.Passwd
            };

            bool create = _userService.Create(newUser);
            if(create)
            {
                User user = _userService.Get(newUser.Email);
                HttpContext.Session.SetInt32("id", user.id);
                ViewBag.Id = HttpContext.Session.GetInt32(user.id.ToString());
                ViewBag.Nom = HttpContext.Session.GetString(user.LastName);
                ViewBag.Email = HttpContext.Session.GetString(user.Email);
            } else
            {
                ViewBag.ErrorCreate = "Une erreur est survenue dans le serveur. Veuillez réessayer plus tard !";
                return View(form);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
