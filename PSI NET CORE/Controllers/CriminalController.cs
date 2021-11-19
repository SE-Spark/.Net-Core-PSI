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
    public class CriminalController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        CriminalMapper mapper = new CriminalMapper();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetData()
        {
            var data = await unit.CriminalRepository.get();
            var result = mapper.MapToDomainList(data);
            return Json(new { data = result });
        }
       
        public IActionResult Edit(object id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection collection)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(String id)
        {
            return View();
        }
    }
}