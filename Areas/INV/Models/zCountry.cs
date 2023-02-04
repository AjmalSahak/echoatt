using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zCountry", Schema = "dbo")]
    public class zCountry
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryNameEn { get; set; }
    }
}