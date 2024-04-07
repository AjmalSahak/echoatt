using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Program", Schema = "dbo")]
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
    }
}