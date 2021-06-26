using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model.Client.Data;
using Model.Client.Repositories;
using Model.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Infracstructures.Security;
using WepAppEmpty.Infracstructures.Sessions;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Forms;

namespace WepAppEmpty.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        [AnonymousRequired]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        //[AllowAnonymous] : Ceci permet d'être authentifié ou non pour utiliser la ressource. AllowAnonymous prend le pas sur tous les autre attribut
        [AnonymousRequired]
        public IActionResult Login()
        {
            LoginForm form = new LoginForm();

            return View(form);
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Login(LoginForm form)
        {
            if(!ModelState.IsValid)
                return View(form);

            User user = _authRepository.Login(form.Email, form.Passwd);


            if (user is null)
            {
                //ModelState.AddModelError("", "L'email ou le mot de passe ne sont pas valide");
                ViewBag.ErrorPasswd = ("Le mot de passe est incorrect");
                return View(form);
            }

            //Ici on met l'utilisateur connecté dans la session
            HttpContext.Session.SetInt32("id", user.Id);
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("email", user.LastName);

            //Ici recuperer la session pour envoyer à notre vue
            //ViewBag.Id = HttpContext.Session.GetInt32(user.id.ToString());
            //ViewBag.Nom = HttpContext.Session.GetString(user.LastName);
            //ViewBag.Email = HttpContext.Session.GetString(user.Email);

            _sessionManager.User = new UserSession
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
            return RedirectToAction("Index", "Home");
        }

        [AnonymousRequired]
        public IActionResult Signup()
        {
            CreateUserForm form = new CreateUserForm();

            return View(form);
        }


        [HttpPost]
        [AnonymousRequired]
        public IActionResult Signup(CreateUserForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User newUser = new User(form.LastName, form.FirstName, form.Email, form.Passwd);

            _authRepository.Register(newUser);

            return RedirectToAction("Index", "Home");
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            _sessionManager.Clear();

            return RedirectToAction("Index");
        }
    }
}
