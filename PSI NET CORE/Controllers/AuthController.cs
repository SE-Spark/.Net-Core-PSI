using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Repo;

namespace PSI_NET_CORE.Controllers
{
    public class AuthController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        public IActionResult Index()
        {
            var sess = HttpContext.Session.GetString(SessionManager.SessionUserName);
            if (sess != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult RegisterView()
        {
            return View();
        }
        public IActionResult LoginView()
        {
            return View();
        }
        public IActionResult RegisterUser(Register l)
        {
            if (ModelState.IsValid)
            {
                var re = new Login
                {
                    Username = l.Username,
                    Password = l.Password
                };
                var response = unit.LoginRepository.insertUser(re);
                if (response == 1)
                {
                    HttpContext.Session.SetString(SessionManager.SessionUserName, l.Username);
                    var message = HttpContext.Session.GetString(SessionManager.SessionUserName);
                    if (message == null)
                    {
                        ViewData["message"] = "Registration failed,could not set Session";
                        return View("Index");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ViewData["message"] = "Registration failed, invalid credentials, user may exist with similar username";
                return View("Index");
            }
            ViewData["message"] = "Registration failed, empty fields or credentials mismatch";
            return View("Index");
        }
        public IActionResult LoginUser(Login lg)
        {
            if (ModelState.IsValid)
            {
                var response = unit.LoginRepository.Validate(lg);
                if (response == 1)
                {
                    HttpContext.Session.SetString(SessionManager.SessionUserName, lg.Username);

                    var message = HttpContext.Session.GetString(SessionManager.SessionUserName);
                    if (message == null)
                    {
                        ViewData["message"] = "Login failed,could not set Session";
                        return View("Index");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ViewData["message"] = "Login failed, invalid credentials";
                return View("Index");
            }
            return View("Index");
        }
    }
}