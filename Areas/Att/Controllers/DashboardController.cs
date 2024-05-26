using AlphaTechMIS.Areas.Att.ViewModal;
using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.Att.Controllers
{
    public class DashboardController : Controller
    {
        AttDBContext db = new AttDBContext();
        // GET: Att/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GraphOneData(DateTime? startDate, DateTime? endDate)
        {
            var data = db.Database.SqlQuery<ParticipantVM>(@"exec [dbo].[GraphOneData] {0},{1}", startDate, endDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GraphTwoData(DateTime? startDate, DateTime? endDate)
        {
            var data = db.Database.SqlQuery<ParticipantVM>(@"exec [dbo].[GraphTwoData] {0},{1}", startDate, endDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GraphThreeData(DateTime? startDate, DateTime? endDate)
        {
            var data = db.Database.SqlQuery<SessionVM>(@"exec [dbo].[GraphThreeData] {0},{1}", startDate, endDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GraphFourData(DateTime? startDate, DateTime? endDate)
        {
            var data = db.Database.SqlQuery<SessionVM>(@"exec [dbo].[GraphFourData] {0},{1}", startDate, endDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}