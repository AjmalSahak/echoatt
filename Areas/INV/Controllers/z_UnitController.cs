using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class z_UnitController : LangController
    {
        // GET: INV/z_Unit
        INVDBContext db;
        public z_UnitController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(z_Unit NewRec)
        {
            db.z_Units.Add(NewRec);
            db.SaveChanges();
            return Json("Record_Saved");
        }
        [HttpPost]
        public ActionResult Edit(z_Unit InputRec)
        {
            z_Unit FoundRec = db.z_Units.Find(InputRec.UnitID);
            FoundRec.UnitName = InputRec.UnitName;
            db.SaveChanges();
            return Json("Record_Update");
        }
        public ActionResult UnitList()
        {
            return Json(db.z_Units.ToList(), JsonRequestBehavior.AllowGet);
        }
        


    }
}