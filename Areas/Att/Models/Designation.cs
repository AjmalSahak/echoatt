using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Designation", Schema = "dbo")]
    public class Designation
    {
        [Key]
        public int DesID { get; set; }
        public string DesTitle { get; set; }
      
    }
}