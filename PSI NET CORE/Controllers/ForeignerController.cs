using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_NET_CORE.Network.Repo;

namespace PSI_NET_CORE.Controllers
{
    public class ForeignerController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        public ActionResult Index()
        {
            return View(unit.ForeignerRepository.get());
        }
        public ActionResult GetData()
        {
            return Json(new { data = unit.ForeignerRepository.get() });
        }
        public ActionResult Create()
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
        public ActionResult Edit(object id)
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