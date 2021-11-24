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
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
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
                     return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            return View("Index");
        }
    }
}