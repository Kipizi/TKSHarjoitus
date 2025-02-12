﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKSHarjoitus.Models;

namespace WebAppFirst5MVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.LoggedStatus = "Logged out";
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");

            }
            else ViewBag.LoggedStatus = "Logged in";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.LoggedStatus = "Logged out";
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Logged in";
                ViewBag.Message = "Yhtiön perustietojen kuvailua";
                ViewBag.Herja = "Ota yhteyttä!";

                return View();
            }
        }

        public ActionResult Contact()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Logged in";
                ViewBag.Message = "Yhteystietojamme";
                ViewBag.UserName = Session["UserName"];
                return View();
            }
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Saapumisohje";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Logins LoginModel)
        {
            TilausDBEntities db = new TilausDBEntities();
            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ -kyselyllä
            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);
            if (LoggedUser != null)
            {
                ViewBag.LoginMessage = "Successfull login";
                ViewBag.LoggedStatus = "In";
                Session["UserName"] = LoggedUser.UserName;
                return RedirectToAction("Index", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index
            }
            else
            {
                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Login", LoginModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Loggedout", "Home"); //Uloskirjautumisen jälkeen pääsivulle
        }
        public ActionResult Loggedout()
        {
            ViewBag.Message = "Saapumisohje";

            return View();
        }

    }
}