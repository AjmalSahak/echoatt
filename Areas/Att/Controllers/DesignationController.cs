using EchoAttendance.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoAttendance.Areas.Att.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Att/Designation
        AttDBContext db;
        public DesignationController()
        {
            db = new AttDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Designation NewRec)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(NewRec);
                db.SaveChanges();
                return Json("Record_Saved");
            }

            string validationErrors = string.Join("<br />",
                ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToArray());
            return Content(validationErrors, "text/html");

        }
        public ActionResult DesignationList()
        {
           
            var jsondata = Json(db.Designations.ToList().OrderByDescending(d =>d.DesID), JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        [HttpPost]
        public ActionResult Edit(Designation formRecord)
        {
            if (ModelState.IsValid)
            {
              var existingParticipant = db.Designations.Find(formRecord.DesID);

                if (existingParticipant != null)
                {
                    existingParticipant.DesTitle = formRecord.DesTitle;
                 
                    db.SaveChanges();
                    return Json("Record_Update");
                }
                else
                {
                    return Json("Record not found.");
                }
            }
            string validationErrors = string.Join("<br />",
                ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToArray());
            return Content(validationErrors, "text/html");
        }

    }
}