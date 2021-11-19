using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_NET_CORE.Network.Mappers;
using PSI_NET_CORE.Network.Repo;

namespace PSI_NET_CORE.Controllers
{
    public class SuspectController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        SuspectMapper mapper = new SuspectMapper();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetData()
        {
            var data = await unit.SuspectRepository.get();
            var result = mapper.MapToDomainList(data);
            return Json(new { data =result});
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
        public IActionResult Delete(object id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            return View();
        }
    }
}