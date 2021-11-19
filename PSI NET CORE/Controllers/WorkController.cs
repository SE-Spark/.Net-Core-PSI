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
    public class WorkController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        WorkMapper mapper = new WorkMapper();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetData()
        {
            var data = await unit.WorkRepository.get();
            var result = mapper.MapToDomainList(data);
            return Json(new { data = result});
        }
        [HttpGet]
        public IActionResult CreateUpdate(string id)
        {
            if (String.IsNullOrEmpty(id))
                return View(new Work());

            var data = unit.WorkRepository.get(Guid.Parse(id));
            var res=mapper.MapToDomain(data);
            return View(res);
        }
        [HttpPost]
        public IActionResult CreateUpdate(Work t)
        {
            var input=mapper.MapToDto(t);
            if (input.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                var output = unit.WorkRepository.insert(input);
                if (output == 1)
                    return Json(new { success = true, message = "Added Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                var output = unit.WorkRepository.update(input.Id, input);
                if (output == 1)
                    return Json(new { success = true, message = "Updated Successfully" }, new Newtonsoft.Json.JsonSerializerSettings());
                return Json(new { success = false, message = "process failed" }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        }

        [HttpPost]
        public IActionResult Delete(String id)
        {
            var result = unit.WorkRepository.delete(Guid.Parse(id));
            if (result == 1)
                return Json(new {success=true,message="Deleted SuccessFully" },new Newtonsoft.Json.JsonSerializerSettings());
            return Json(new {success=false,message="Deletion failed" },new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}