using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Participant", Schema = "dbo")]
    public class Participant
    {
        [Key]
        public int ParticipantID { get; set; }
        public string ParticipantName { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public int SiteID { get; set; }
        public int DesID { get; set; }
        public bool IsSessionOrganizer { get; set; }
        public bool Gender { get; set; }
    }
}