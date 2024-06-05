using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.ViewModal
{
    public class SiteVM
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public bool IsHub { get; set; }
        public bool IsEchoSite { get; set; }
        public string EmailID { get; set; }
    }
}