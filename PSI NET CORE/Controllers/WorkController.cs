using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_NET_CORE.Network.Repo;

namespace PSI_NET_CORE.Controllers
{
    public class WorkController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        public IActionResult Index()
        {
            return View("CreateUpdate");
        }
        public async Task<ActionResult> GetData()
        {
            return Json(new { data = await unit.WorkRepository.get() });
        }
        public IActionResult Create()
        {
            return View();
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