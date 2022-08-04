using Maternity.Helper;
using Maternity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maternity.Controllers
{
    public class MotherController : Controller
    {
        // GET: Mother
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetMotherPartialView()
        {
            var ListMother = new MaternityService.Mother();
            var ViewModel = ListMother.List();

            return PartialView("_Mother", ViewModel);
        }

        public ActionResult GetById(int id)
        {
            var Mother = new MaternityService.Mother();

            var ViewMother = Mother.Get(id);
            ViewMother.BabyList = Mother.FindBabys(ViewMother.Id);
            return View(ViewMother);
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Mother = new MaternityService.Mother();

            if (id.HasValue) return View(Mother.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(MotherModel Mother)
        {
            var OtherMother = new MaternityService.Mother();

            if (!OtherMother.Update(Mother))
            {
                OtherMother.Add(Mother);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var MotherRemove = new MaternityService.Mother();
            MotherRemove.Remove(id);
            return RedirectToAction("Index");
        }
    }
}