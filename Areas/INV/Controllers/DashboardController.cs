using AlphaTechMIS.Areas.INV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class DashboardController : Controller
    {
        // GET: INV/Dashboard
        INVDBContext db;
        public ActionResult Index()
        {
            return View();
        }
        public DashboardController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
    }
}