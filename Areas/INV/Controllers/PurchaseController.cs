using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: INV/Purchase
        INVDBContext db;
        public PurchaseController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDealer(int TypeID)
        {
            var data = db.Database.SqlQuery<DealerVM>("EXEC DBO.GetDealer {0}", TypeID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}