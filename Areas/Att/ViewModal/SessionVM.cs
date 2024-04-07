using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.Att.ViewModal
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
    }
}