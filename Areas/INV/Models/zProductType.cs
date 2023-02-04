using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zProductType", Schema = "dbo")]
    public class zProductType
    {
        [Key]
        public int PTID { get; set; }
        public string PName { get; set; }
        public string Description { get; set; }
        public int UniteID { get; set; }
    }
}