using AlphaTechMIS.Areas.INV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class z_ProductController : Controller
    {
        // GET: INV/z_Product
        INVDBContext db;
        public z_ProductController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult zCategoryList()
        {
            return Json(db.zProCategorys.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zTypeList()
        {
            return Json(db.zProductTypes.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zProductList()
        {
            return Json(db.zProducts.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}