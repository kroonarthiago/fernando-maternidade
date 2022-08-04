using Maternity.Helper;
using Maternity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maternity.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public PartialViewResult GetDoctorPartialView()
        {
            var ListDoctor = new MaternityService.Doctor();
            var ViewModel = ListDoctor.List();

            return PartialView("_Doctor", ViewModel);
        }

        public ActionResult GetById(int id)
        {

            var BabyDoctor = new MaternityService.Baby_Doctor();
            var Doctor = new MaternityService.Doctor();

            var DoctorById = Doctor.Get(id);
            DoctorById.BabysList = BabyDoctor.BabyRelatedToDoc(id);
            return View(DoctorById);
        }


        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Doctor = new MaternityService.Doctor();

            if (id.HasValue) return View(Doctor.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(DoctorModel Doctor)
        {
            var OtherDoctor = new MaternityService.Doctor();

            if (!OtherDoctor.Update(Doctor))
            {
                OtherDoctor.Add(Doctor);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var DoctorRemove = new MaternityService.Doctor();
            DoctorRemove.Remove(id);
            return RedirectToAction("Index");
        }
    }
}