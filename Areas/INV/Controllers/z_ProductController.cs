using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
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
        [HttpPost]
        public ActionResult SaveCategory(zProCategory NewRec)
        {
            db.zProCategorys.Add(NewRec);
            db.SaveChanges();
            return Json("Record_Saved");
        }
        [HttpPost]
        public ActionResult EditCategory(zProCategory InputRec)
        {
            zProCategory FoundRec = db.zProCategorys.Find(InputRec.PCID);
            FoundRec.Category = InputRec.Category;
            db.SaveChanges();
            return Json("Record_Update");
        }
        [HttpPost]
        public ActionResult SaveType(zProductType NewRec)
        {
            db.zProductTypes.Add(NewRec);
            db.SaveChanges();
            return Json("Record_Saved");
        }
        [HttpPost]
        public ActionResult EditType(zProductType InputRec)
        {
            zProductType FoundRec = db.zProductTypes.Find(InputRec.PTID);
            FoundRec.PCID = InputRec.PCID;
            FoundRec.UnitID = InputRec.UnitID;
            FoundRec.TName = InputRec.TName;
            db.SaveChanges();
            return Json("Record_Update");
        }
        [HttpPost]
        public ActionResult SaveProduct(zProduct NewRec)
        {
            db.zProducts.Add(NewRec);
            db.SaveChanges();
            return Json("Record_Saved");
        }
        [HttpPost]
        public ActionResult EditProduct(zProduct InputRec)
        {
            zProduct FoundRec = db.zProducts.Find(InputRec.ProductID);
            FoundRec.PTID = InputRec.PTID;
            FoundRec.PName = InputRec.PName;
            FoundRec.PCode = InputRec.PCode;
            FoundRec.DefualtPurchasePrice = InputRec.DefualtPurchasePrice;
            FoundRec.DefualtSalePrice = InputRec.DefualtSalePrice;
            FoundRec.Description = InputRec.Description;
            db.SaveChanges();
            return Json("Record_Update");
        }
        public ActionResult zCategoryList()
        {
            return Json(db.zProCategorys.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zTypeList()
        {
            return Json(db.zProductTypes.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zTypeListByID(int PCID)
        {
            return Json(db.zProductTypes.ToList().Where(x => x.PCID == PCID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zType_List()
        {
            //var data = (from a in db.zProductTypes
            //                  join b in db.z_Units on a.UniteID equals b.UnitID
            //                  join c in db.zProCategorys on a.PCID equals c.PCID
            //                  select new { Types = a, Category = b, Unit = c }).ToList();
            var data = db.Database.SqlQuery<z_ProductListVM>(@"EXEC DBO.zPTypeList").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult zProductList(int PTID)
        {
            return Json(db.zProducts.ToList().Where(x => x.PTID == PTID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult findProductByID(int ProductID)
        {
            return Json(db.zProducts.Find(ProductID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductList()
        {
            return Json(db.zProducts.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult zProduct_List()
        {
            var data = db.Database.SqlQuery<z_ProductVM>(@"EXEC DBO.zProductList").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductUnit(int ProductID)
        {
            var data = db.Database.SqlQuery<z_Unit>(@"SELECT U.UnitID,U.UnitName FROM DBO.zProduct P 
LEFT JOIN DBO.zProductType PT ON PT.PTID=P.PTID
LEFT JOIN DBO.z_Unit U ON U.UnitID=PT.UnitID

WHERE P.ProductID={0}", ProductID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}