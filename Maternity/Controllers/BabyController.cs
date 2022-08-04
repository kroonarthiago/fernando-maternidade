using Maternity.Helper;
using Maternity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maternity.Controllers
{
    public class BabyController : Controller
    {
        // GET: Baby
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetBabyPartialView()
        {
            var ListBaby = new MaternityService.Baby();
            var ViewModel = ListBaby.List();

            return PartialView("_Baby", ViewModel);
        }
        public ActionResult GetById(int id)
        {
            var BabyDoctor = new MaternityService.Baby_Doctor();
            var Baby = new MaternityService.Baby();

            var BabyById = Baby.Get(id);
            BabyById.DoctorList = BabyDoctor.DocsRelatedToBaby(id);

            return View(BabyById);
        }


        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Baby = new MaternityService.Baby();

            if (id.HasValue) return View(Baby.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(BabyModel Baby)
        {
            var OtherBaby = new MaternityService.Baby();

            if (!OtherBaby.Update(Baby))
            {
                OtherBaby.Add(Baby);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var BabyRemove = new MaternityService.Baby();
            BabyRemove.Remove(id);
            return RedirectToAction("Index");
        }
    }
}