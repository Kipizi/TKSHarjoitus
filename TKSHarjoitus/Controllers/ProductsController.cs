using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKSHarjoitus.Models;


namespace TKSHarjoitus.Controllers
{
    public class TuotteetController : Controller
    {
        // GET: Products
        public ActionResult Tuotteet()
        {
            ViewBag.LoggedStatus = "Log in/out";
            TilausDBEntities db = new TilausDBEntities();
            List<Tuotteet> model = db.Tuotteet.ToList();
            db.Dispose();
            return View(model);
        }
        public ActionResult Tuotteet2()
        {
            ViewBag.LoggedStatus = "Log in/out";
            TilausDBEntities db = new TilausDBEntities();
            List<Tuotteet> model = db.Tuotteet.ToList();
            db.Dispose();
            return View(model);
        }
    }
}