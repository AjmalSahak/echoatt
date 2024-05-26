using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.Att.ViewModal
{
    public class ParticipantVM
    {
        public int ParticipantID { get; set; }
        public string ParticipantName { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public int SiteID { get; set; }
        public int DesID { get; set; }
        public string DesTitle { get; set; }
        public string SiteName { get; set; }
        public bool IsSessionOrganizer { get; set; }
        public string Gender { get; set; }

        public string Province { get; set; } //hk
        public int Total { get; set; } //hk

    }
}