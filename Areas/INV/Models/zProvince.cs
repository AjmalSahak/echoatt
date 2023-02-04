using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zProvince", Schema = "dbo")]
    public class zProvince
    {
        [Key]
        public int ProvinceID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }

    }
}