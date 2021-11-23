using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Mappers;
using PSI_NET_CORE.Network.Repo;

namespace PSI_NET_CORE.Controllers
{
    public class ForeignerController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        ForeignerMapper mapper = new ForeignerMapper();
        public ActionResult Index()
        {
            var sess = HttpContext.Session.GetString(SessionManager.SessionUserName);
            if (sess == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }
        public async Task<ActionResult> GetData()
        {
            var data = await unit.ForeignerRepository.get();
            var foreigners = (from t in data select new Foreigner
            {
                Id = t.Id.ToString(),
                FirstName = t.FirstName,
                LastName = t.LastName,
                PassPortNo = t.PassPortNo,
                City = t.City,
                Country = t.Country,
                DateIn = t.DateIn,
                DateOut = t.DateOut
            }).ToList();
            return Json(new { data = foreigners });
        }
        [HttpGet]
        public IActionResult CreateUpdate(string id)
        {
            if (String.IsNullOrEmpty(id))
                return View(new Foreigner());

            var data = unit.ForeignerRepository.get(Guid.Parse(id));
            var res = mapper.MapToDomain(data);
            return View(res);
        }
        [HttpPost]
        public IActionResult CreateUpdate(Foreigner t)
        {
            var input = mapper.MapToDto(t);
            if (String.IsNullOrEmpty(t.Id))
            {
                var output = unit.ForeignerRepository.insert(input);
                if (output == 1)
                    return Json(new { success = true, message = "Added Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                var output = unit.ForeignerRepository.update(input.Id, input);
                if (output == 1)
                    return Json(new { success = true, message = "Updated Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        }

        [HttpPost]
        public IActionResult Delete(String id)
        {
            var result = unit.ForeignerRepository.delete(Guid.Parse(id));
            if (result == 1)
                return Json(new { success = true, message = "Deleted SuccessFully" }, new Newtonsoft.Json.JsonSerializerSettings());
            return Json(new { success = false, message = "Deletion failed" }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}