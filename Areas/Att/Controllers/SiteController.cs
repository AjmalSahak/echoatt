using EchoAttendance.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoAttendance.Areas.Att.Controllers
{
    public class SiteController : Controller
    {
        // GET: Att/Site
        AttDBContext db;
        public SiteController()
        {
            db = new AttDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Site NewRec)
        {
            if (ModelState.IsValid)
            {
                Guid newGuid = Guid.NewGuid();
                NewRec.EncodeID = newGuid.ToString();
                db.Sites.Add(NewRec);
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
        public ActionResult SiteList()
        {
            var data = (from p in db.Sites
                        join d in db.Provinces on p.ProvinceID equals d.ProvinceID
                        orderby p.SiteID descending
                        select new SiteVM
                        {
                            SiteID = p.SiteID,
                            SiteName = p.SiteName,
                            SiteCode = p.SiteCode,
                            ProvinceID = p.ProvinceID,
                            ProvinceName = d.ProvinceName,
                            EstablishmentDate = p.EstablishmentDate,
                            IsHub = p.IsHub,
                            IsEchoSite = p.IsEchoSite,
                            EmailID = p.EmailID,
                        }).ToList();
           
        var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        [HttpPost]
        public ActionResult Edit(Site formRecord)
        {
            if (ModelState.IsValid)
            {
                var foundRec = db.Sites.Find(formRecord.SiteID);

                if (foundRec != null)
                {
                    foundRec.SiteName = formRecord.SiteName;
                    foundRec.SiteCode = formRecord.SiteCode;
                    foundRec.ProvinceID = formRecord.ProvinceID;
                    foundRec.EstablishmentDate = formRecord.EstablishmentDate;
                    foundRec.IsHub = formRecord.IsHub;
                    foundRec.IsEchoSite = formRecord.IsEchoSite;
                    foundRec.EmailID = formRecord.EmailID;
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