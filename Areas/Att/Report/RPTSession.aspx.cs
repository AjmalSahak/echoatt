using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using AlphaTechMIS.Areas.Att.ViewModal;

namespace AlphaTechMIS.Areas.Att.Report
{
    public partial class RPTSession : System.Web.UI.Page
    {
        AttDBContext db;
        public RPTSession()
        {
            db = new AttDBContext();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string FromDate = "2000-01-01";
                string ToDate = "2030-01-01";     
              
                FromDate = string.IsNullOrEmpty(Request.Form["FromDate"]) ? FromDate : Request.Form["FromDate"];
                ToDate = string.IsNullOrEmpty(Request.Form["ToDate"]) ? ToDate : Request.Form["ToDate"];

                var dataQuery = db.Database.SqlQuery<SessionReportVM>("exec DBO.GetSessionReportByDate ").ToList();
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Areas/Att/Report/RDLSession.rdlc");
                ReportDataSource source = new ReportDataSource("AttDataSet", dataQuery);
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.LocalReport.Refresh();
            }

        }
    }
}