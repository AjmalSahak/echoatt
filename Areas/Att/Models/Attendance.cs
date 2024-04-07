using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Attendance", Schema = "dbo")]
    public class Attendance
    {
        [Key]
        public int AttID { get; set; }
        public int SessionID { get; set; }
        public int SiteID { get; set; }
        public int ParticipantCount { get; set; }
        public string FileAtt { get; set; }
        public string ImageFile { get; set; }
        public string VideoURL { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}