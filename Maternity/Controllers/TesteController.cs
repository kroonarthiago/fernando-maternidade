using Maternity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maternity.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            var ListBaby = new MaternityService.Baby();
            var ViewModel = ListBaby.List();
            return View(ViewModel);
        }
    }
}