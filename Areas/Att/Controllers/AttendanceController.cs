using EchoAttendance.Areas.Att.Models;
using EchoAttendance.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoAttendance.Areas.Att.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Att/Attendance
        AttDBContext db;
        public AttendanceController()
        {
            db = new AttDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult ValidateUser(int SiteID2, string EmailID)
        {

            var data = db.Sites.Where(x => x.SiteID == SiteID2 && x.EmailID == EmailID).FirstOrDefault();
            if (data != null)
                return Json(data.EncodeID, JsonRequestBehavior.AllowGet);
            else
                return Json("false", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index(string EncodeID)
        {
            if (/*User.IsInRole("SuperAdmin") &&*/ EncodeID == "all")
            {
                var data = db.Sites.ToList();
                ViewBag.SiteID = new SelectList(data, "SiteID", "SiteName");
                ViewBag.SiteID2 = new SelectList(data, "SiteID", "SiteName");
            }
            else
            {
                var siteIDFiltered = db.Sites.Where(x => x.EncodeID == EncodeID).ToList();
                ViewBag.SiteID = new SelectList(siteIDFiltered, "SiteID", "SiteName");
                ViewBag.SiteID2 = new SelectList(siteIDFiltered, "SiteID", "SiteName");
            }
            ViewBag.DesID = new SelectList(db.Designations, "DesID", "DesTitle");
         
            var sessions = db.Sessions.ToList();

            var sessionTopics = sessions.Join(db.Programs,
                                     s => s.ProgramID,
                                     p => p.ProgramID,
                                     (s, p) => new
                                     {
                                         s.SessionID,
                                         SessionTopic = p.ProgramName + " | " + s.SessionDate.ToString("yyyy-MM-dd") + " | " + s.SessionTopic
                                     });

            ViewBag.SessionID = new SelectList(sessionTopics, "SessionID", "SessionTopic");
            return View();
        }
        public ActionResult SiteLogin()
        {
            ViewBag.SiteID2 = new SelectList(db.Sites, "SiteID", "SiteName");
            return View();
        }
        public ActionResult SessionAttendance()
        {
            var sessions = db.Sessions.ToList();

            // Convert the fetched data to the desired format
            var sessionTopics = sessions.Join(db.Programs,
                                    s => s.ProgramID,
                                    p => p.ProgramID,
                                    (s, p) => new
                                    {
                                        s.SessionID,
                                        SessionTopic = p.ProgramName + " | " + s.SessionDate.ToString("yyyy-MM-dd") + " | " + s.SessionTopic
                                    });

            ViewBag.SessionID = new SelectList(sessionTopics, "SessionID", "SessionTopic");

            return View(); 
        }
     
        public ActionResult GetAttendanceBySession(int SessionID)
        {
            var data = db.Database.SqlQuery<AttendanceVM>(@"EXEC DBO.GetAttendanceBySession {0}",SessionID).ToList();
            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        public ActionResult GetAttendanceDetail(int AttID)
        {
            var data = db.Database.SqlQuery<ParticipantVM>(@"EXEC DBO.GetAttendanceDetail {0}", AttID).ToList();
            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        [HttpPost]
        public ActionResult SaveAttendance(int SessionID, int SiteID2, List<int> ParticipantIDs, HttpPostedFileBase AttendanceFile/*, HttpPostedFileBase SessionImage*/)
        {
            if (db.Attendances.Where(x => x.SessionID == SessionID && x.SiteID == SiteID2).Count() > 0)
            {
                return Json("This session attendance is Already submited");
            }
            if (db.Sessions.Where(x => x.SessionID == SessionID).First().SessionDate > DateTime.Now)
            {
                return Json("The session has not taken place yet.");
            }
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Step 1: Save files to server with timestamp appended to file names
                    string attendanceFilePath = "";
             
                    string fullFileName = null;
                    if (AttendanceFile != null && AttendanceFile.FileName != "")
                    {
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(AttendanceFile.FileName);
                        var extension = Path.GetExtension(AttendanceFile.FileName).ToLower();
                        if (extension != ".pdf" && extension != ".pptx" && extension != ".ppt")
                            return Json("FileFormatError");
                        if (AttendanceFile.ContentLength > 2097152)
                            return Json("FileSizeError");
                        string TimeStamp = DateTime.Now.ToString("yyyMMddHmmss");
                        fullFileName =   TimeStamp + extension;
                         attendanceFilePath = "/Uploads/AttendanceFile/" + fullFileName;
                        string filePath = Path.Combine(Server.MapPath("~/Uploads/AttendanceFile"), fullFileName);
                        AttendanceFile.SaveAs(filePath);
                    }


                    // Step 2: Insert record into Attendance table
                    var attendance = new Attendance
                    {
                        SessionID = SessionID,
                        SiteID = SiteID2,
                        CreatedDate = DateTime.Now,
                        ParticipantCount = ParticipantIDs.Count(),
                        FileAtt = attendanceFilePath,
                        //ImageFile = sessionImagePath,
                        VideoURL = "" // You can set this if you have a video URL
                    };
                    db.Attendances.Add(attendance);
                    db.SaveChanges();

                    // Step 3: Retrieve generated AttID
                    int attID = attendance.AttID;

                    // Step 4: Insert records into AttendanceDetail table
                    foreach (var participantID in ParticipantIDs)
                    {
                        var attendanceDetail = new AttendanceDetail
                        {
                            AttID = attID,
                            ParticipantID = participantID
                        };
                        db.AttendanceDetails.Add(attendanceDetail);
                    }
                    db.SaveChanges();

                    dbContextTransaction.Commit();

                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    // Handle exception
                    return Json(ex.Message, JsonRequestBehavior.AllowGet);
                }
            }
        }

    }
}