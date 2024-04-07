using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    [Table("Province", Schema = "dbo")]
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
    }
}