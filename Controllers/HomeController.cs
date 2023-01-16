using AlphaTechMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Controllers
{
    public class HomeController : LangController
    {
        public ActionResult ChangeLanguage(string lang)
        {
            if (lang == "fa")
            {
                lang = "ur";
            }
            new LanguageManager().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult ManualChangeLanguage(string lang)
        {

            new LanguageManager().SetLanguage(lang);
            return Json("true");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}