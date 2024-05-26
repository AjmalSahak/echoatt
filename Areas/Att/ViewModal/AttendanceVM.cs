using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.Att.ViewModal
{
    public class AttendanceVM
    {
        public int AttID { get; set; }
        public string ProvinceName { get; set; }
        public string SiteName { get; set; }
        public int ParticipantCount { get; set; }
        public string FileAtt { get; set; }
        public string ImageFile { get; set; }
        public string VideoURL { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string isPresent { get; set; }
        public bool IsEchoSite { get; set; }
    }
}