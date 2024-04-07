using AlphaTechMIS.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.Att.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Att/Participant
        AttDBContext db;
        public ParticipantController()
        {
            db = new AttDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            ViewBag.DesID = new SelectList(db.Designations, "DesID", "DesTitle");
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Participant NewRec)
        {
            if (ModelState.IsValid)
            {
                NewRec.ParticipantName = TrimAndTitleCase(NewRec.ParticipantName);
                NewRec.FatherName = TrimAndTitleCase(NewRec.FatherName);
                NewRec.EmailID = NewRec.EmailID.ToLower(); // Convert email to lowercase

                // Check for duplicates based on name and email or name and contact
                bool duplicateExists = db.Participants.Any(p =>
                    (p.ParticipantName == NewRec.ParticipantName && p.EmailID == NewRec.EmailID && p.SiteID == NewRec.SiteID) ||
                    (p.ParticipantName == NewRec.ParticipantName && p.ContactNo == NewRec.ContactNo && p.SiteID == NewRec.SiteID));

                if (duplicateExists)
                {
                    return Json("A participant with the same name and either email or contact number already exists.");
                }

                db.Participants.Add(NewRec);
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
        private string TrimAndTitleCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.Trim());
        }
        public ActionResult ParticipantList()
        {
            var data = (from p in db.Participants
                        join d in db.Designations on p.DesID equals d.DesID
                        join s in db.Sites on p.SiteID equals s.SiteID
                        orderby p.ParticipantID descending
                        select new ParticipantVM
                        {
                            ParticipantID = p.ParticipantID,
                            ParticipantName = p.ParticipantName,
                            FatherName = p.FatherName,
                            ContactNo = p.ContactNo,
                            EmailID = p.EmailID,
                            SiteName = s.SiteName,
                            DesTitle = d.DesTitle,
                            DesID = p.DesID,
                            SiteID = p.SiteID,
                            IsSessionOrganizer = p.IsSessionOrganizer
                        }).ToList();

            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        public ActionResult ParticipantListBySite(int SiteID = 0)
        {
            var data = (from p in db.Participants
                        join d in db.Designations on p.DesID equals d.DesID
                        join s in db.Sites on p.SiteID equals s.SiteID
                        where p.SiteID == SiteID
                        orderby p.ParticipantID descending
                        select new ParticipantVM
                        {
                            ParticipantID = p.ParticipantID,
                            ParticipantName = p.ParticipantName,
                            FatherName = p.FatherName,
                            ContactNo = p.ContactNo,
                            EmailID = p.EmailID,
                            SiteName = s.SiteName,
                            DesTitle = d.DesTitle,
                            DesID = p.DesID,
                            SiteID = p.SiteID
                        }).ToList();

            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        [HttpPost]
        public ActionResult Edit(Participant updatedParticipant)
        {
            if (ModelState.IsValid)
            {
                updatedParticipant.ParticipantName = TrimAndTitleCase(updatedParticipant.ParticipantName);
                updatedParticipant.FatherName = TrimAndTitleCase(updatedParticipant.FatherName);
                updatedParticipant.EmailID = updatedParticipant.EmailID.ToLower();
                // Check for duplicates based on name and email or name and contact, excluding the current participant
                bool duplicateExists = db.Participants.Any(p =>
                    (p.ParticipantName == updatedParticipant.ParticipantName && p.EmailID == updatedParticipant.EmailID && p.SiteID == updatedParticipant.SiteID && p.ParticipantID != updatedParticipant.ParticipantID) ||
                    (p.ParticipantName == updatedParticipant.ParticipantName && p.ContactNo == updatedParticipant.ContactNo && p.SiteID == updatedParticipant.SiteID && p.ParticipantID != updatedParticipant.ParticipantID));

                if (duplicateExists)
                {
                    return Json("A participant with the same name and either email or contact number already exists.");
                }

                // Retrieve the existing participant from the database
                var existingParticipant = db.Participants.Find(updatedParticipant.ParticipantID);

                if (existingParticipant != null)
                {
                    // Update the existing participant with the new values
                    existingParticipant.ParticipantName = updatedParticipant.ParticipantName;
                    existingParticipant.FatherName = updatedParticipant.FatherName;
                    existingParticipant.ContactNo = updatedParticipant.ContactNo;
                    existingParticipant.EmailID = updatedParticipant.EmailID;
                    existingParticipant.SiteID = updatedParticipant.SiteID;
                    existingParticipant.DesID = updatedParticipant.DesID;
                    existingParticipant.IsSessionOrganizer = updatedParticipant.IsSessionOrganizer;

                    db.SaveChanges();
                    return Json("Record_Update");
                }
                else
                {
                    return Json("Participant not found.");
                }
            }

            string validationErrors = string.Join("<br />",
                ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToArray());
            return Content(validationErrors, "text/html");
        }
        public ActionResult SessionOrganizer()
        {
            return View();
        }
        public ActionResult ToggleParticipantStatus(bool IsSessionOrganizer,int ParticipantID)
        {
            var foundRec = db.Participants.Find(ParticipantID);
            if (foundRec != null)
            {
                foundRec.IsSessionOrganizer = !IsSessionOrganizer;
                db.SaveChanges();
                return Json(true);
            }
            else
                return Json(false);
        }

    }
}