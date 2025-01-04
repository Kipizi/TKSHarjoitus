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
        public ActionResult Tuotteet()
        {
            // Create a new instance of the database context
            using (TilausDBEntities db = new TilausDBEntities())
            {
                // Check if the user is authenticated
                if (Session["UserName"] != null)
                {
                    ViewBag.LoggedStatus = "Logged in";  // User is logged in
                }
                else
                {
                    ViewBag.LoggedStatus = "Logged out"; // User is logged out
                }

                // Retrieve the list of products from the database
                List<Tuotteet> model = db.Tuotteet.ToList();

                // Return the view with the model data
                return View(model);
            }
        }





        public ActionResult Tuotteet2()
        {
            // Create a new instance of the database context
            using (TilausDBEntities db = new TilausDBEntities())
            {
                // Check if the user is authenticated
                if (Session["UserName"] != null)
                {
                    ViewBag.LoggedStatus = "Logged in";  // User is logged in
                }
                else
                {
                    ViewBag.LoggedStatus = "Logged out"; // User is logged out
                }

                // Retrieve the list of products from the database
                List<Tuotteet> model = db.Tuotteet.ToList();

                // Return the view with the model data
                return View(model);
            }
        }
    }
}