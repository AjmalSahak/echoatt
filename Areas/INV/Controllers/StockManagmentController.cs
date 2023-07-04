using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class StockManagmentController : Controller
    {
        // GET: INV/StockManagment
        INVDBContext db;
        public StockManagmentController()
        {
            db = new INVDBContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetStockProducts()
        {
            var data = db.Database.SqlQuery<StockSettingVM>("EXEC DBO.GetStockProducts").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}