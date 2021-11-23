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
    public class CitizenController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();

        // GET: Citizen
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
            var data =await unit.CitizenRepository.get();
            var lis = (from a in data select new Citizen {
                Id=a.Id.ToString(),
                FirstName=a.FirstName,
                LastName=a.LastName,
                NationalID=a.NationalID,
                SubLocation=a.SubLocation,
                Location=a.Location,
                Ward=a.Ward,
                County=a.County
            }).ToList();
            return Json(new { data = lis });
        }
        [HttpGet]
        public ActionResult AddorEdit(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View(new Citizen());
            }
            else
            {
                var data = unit.CitizenRepository.get(Guid.Parse(id));               
                CitizenMapper mapper = new CitizenMapper();
                var citizen = mapper.MapToDomain(data);
                return View(citizen);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(Citizen ct)
        {
            CitizenMapper mapper = new CitizenMapper();
            var input = mapper.MapToDto(ct);
            if (String.IsNullOrEmpty(ct.Id))
            {
                //insert
                var output= unit.CitizenRepository.insert(input);
                if(output==1)
                    return Json(new { success = true, message = "Added Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" },new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                //update
                var output = unit.CitizenRepository.update(input.Id,input);
                if (output == 1)
                    return Json(new { success = true, message = "Updated Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }
        [HttpPost]
        public ActionResult Delete(String id)
        {
            var output = unit.CitizenRepository.delete(Guid.Parse(id));
            if (output == 1)
                return Json(new { success = true, message = "Deleted Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
            return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        // POST: Citizen/Delete/5

    }
}