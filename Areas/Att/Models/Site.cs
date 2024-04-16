using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Site", Schema = "dbo")]
    public class Site
    {
        [Key]
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int ProvinceID { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public bool IsHub { get; set; }
        public bool IsEchoSite { get; set; }
        public string EmailID { get; set; }
        public string EncodeID { get; set; }
    }
}