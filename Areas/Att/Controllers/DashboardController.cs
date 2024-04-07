using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.Att.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Att/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}