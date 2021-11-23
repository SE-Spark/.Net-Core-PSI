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
           
            return View();
        }
        public IActionResult RegisterUser(Register l)
        {
            var re = new Login {
                Username=l.Username,
                Password=l.Password
            };
            var response= unit.LoginRepository.insertUser(re);
            if(response==1)
            {
                HttpContext.Session.SetString(SessionManager.SessionUserName,l.Username);
                return Json(new { success=true,message= "Registration successful, you are now login to the application" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else if (response == 0)
            {
                return Json(new { success = true, message = "Ragistration failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json(new { success = false, message = "Ragistration failed, unknown error" }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public async Task< IActionResult> LoginUser(Login lg)
        {
            
            var response = await unit.LoginRepository.Validate(lg);
            if (response == 1)
            {
                HttpContext.Session.SetString(SessionManager.SessionUserName, lg.Username);
                return Json(new { success = true, message = "Login successful, you are now login to the application" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else if (response == 0)
            {
                return Json(new { success = true, message = "Login failed, invalid credentials" }, new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json(new { success = false, message = "Login failed, unknown error" }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}