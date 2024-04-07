using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.Att.Models
{
    [Table("AttendanceDetail", Schema = "dbo")]

    public class AttendanceDetail
    {
        [Key]
        public int ADID { get; set; }
        public int AttID { get; set; }
        public int ParticipantID { get; set; }
    }
}