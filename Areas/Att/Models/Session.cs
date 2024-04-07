using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Session", Schema = "dbo")]
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        public string SessionTopic { get; set; }
        public DateTime SessionDate { get; set; }
        public int ProgramID { get; set; }
        public int SiteID { get; set; }
        public string PresentationFile { get; set; }
    }
}