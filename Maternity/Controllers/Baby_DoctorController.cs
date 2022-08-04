using Maternity.Helper;
using Maternity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maternity.Controllers
{
    public class Baby_DoctorController : Controller
    {
        // GET: Baby_Doctor
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public PartialViewResult GetBaby_DoctorPartialView()
        {
            var ListBaby_Doctor = new MaternityService.Baby_Doctor();
            var ViewModel = ListBaby_Doctor.List();

            return PartialView("_Baby_Doctor", ViewModel);
        }

        public ActionResult GetById(int id)
        {
            var Baby_Doctor = new MaternityService.Baby_Doctor();
            return View(Baby_Doctor.Get(id));
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Baby_Doctor = new MaternityService.Baby_Doctor();

            if (id.HasValue) return View(Baby_Doctor.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(Baby_DoctorModel Baby_Doctor)
        {
            var OtherBaby_Doctor = new MaternityService.Baby_Doctor();

            if (!OtherBaby_Doctor.Update(Baby_Doctor))
            {
                OtherBaby_Doctor.Add(Baby_Doctor);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var Baby_DoctorRemove = new MaternityService.Baby_Doctor();
            Baby_DoctorRemove.Remove(id);
            return RedirectToAction("Index");
        }
    }
}