using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.ViewModal
{
    public class SessionVM
    {
        public int SessionID { get; set; }
        public string SessionTopic { get; set; }
        public DateTime SessionDate { get; set; }
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string PresentationFile { get; set; }


        public int? Total { get; set; } //hk
        public int? Male { get; set; } //hk
        public int? Female { get; set; } //hk
    }
    public class SessionReportVM
    {
        public string SessionTopic { get; set; }
        public DateTime SessionDate { get; set; }
        public string ProgramName { get; set; }
        public string TotalMale { get; set; }
        public string TotalFemale { get; set; }
    }
}