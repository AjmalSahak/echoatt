using EchoAttendance.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoAttendance.Areas.Att.Controllers
{
    public class SessionController : Controller
    {
        AttDBContext db;
        public SessionController()
        {
            db = new AttDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Session NewRec)
        {
            if (ModelState.IsValid)
            {
                using (var t = db.Database.BeginTransaction())
                {
                    try
                    {
                        HttpPostedFileBase Doc = Request.Files["Attachment"];
                        string fullFileName = null;
                        if (Doc != null && Doc.FileName != "")
                        {
                            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Doc.FileName);
                            var extension = Path.GetExtension(Doc.FileName).ToLower();
                            if (extension != ".pdf" && extension != ".pptx" && extension != ".ppt")
                                return Json("FileFormatError");
                            if (Doc.ContentLength > 2097152)
                                return Json("FileSizeError");
                            string TimeStamp = DateTime.Now.ToString("yyyMMddHmmss");
                            fullFileName = fileNameWithoutExtension + "_" + TimeStamp + extension;
                            NewRec.PresentationFile = "/Uploads/Presentation/" + fullFileName;
                            string filePath = Path.Combine(Server.MapPath("~/Uploads/Presentation"), fullFileName);
                            Doc.SaveAs(filePath);
                        }
                        db.Sessions.Add(NewRec);
                        db.SaveChanges();
                        t.Commit();
                        return Json("saved");
                    }

                    catch (Exception ex)
                    {
                        //t.Rollback();
                        return Json("error" + ex.Message + "-" + ex.InnerException);
                    }
                };
            }
            string validationErrors = string.Join("<br /> ",
            ModelState.Values.Where(E => E.Errors.Count > 0)
                       .SelectMany(E => E.Errors)
                       .Select(E => E.ErrorMessage)
                     .ToArray());
            return Content(validationErrors, "text/html");
        }
        [HttpPost]
        public ActionResult Edit(Session InputRec)
        {
            Session FoundRec = db.Sessions.Find(InputRec.SessionID);
            if (FoundRec != null)
            {
                HttpPostedFileBase Doc = Request.Files["Attachment"];
                string fullFileName = null;
                if (Doc != null && Doc.FileName != "")
                {
                   // var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Doc.FileName);
                    var extension = Path.GetExtension(Doc.FileName).ToLower();
                    if (extension != ".pdf" && extension != ".pptx" && extension != ".ppt")
                        return Json("FileFormatError");
                    if (Doc.ContentLength > 2097152)
                        return Json("FileSizeError");
                    string TimeStamp = DateTime.Now.ToString("yyyMMddHmmss");
                    fullFileName =  TimeStamp + extension;
                    FoundRec.PresentationFile = "/Uploads/Presentation/" + fullFileName;
                    string filePath = Path.Combine(Server.MapPath("~/Uploads/Presentation"), fullFileName);
                    Doc.SaveAs(filePath);
                }
                FoundRec.ProgramID = InputRec.ProgramID;
                FoundRec.SessionTopic = InputRec.SessionTopic;
                FoundRec.SessionDate = InputRec.SessionDate;
                FoundRec.SiteID = InputRec.SiteID;
                db.SaveChanges();
                return Json("update");
            }
            return Json("Not Found");
        }
        public ActionResult SessionList()
        {
            var data = db.Database.SqlQuery<SessionVM>(@"EXEC DBO.SessionList").ToList();
            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
    }
}