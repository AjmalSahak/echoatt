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
        public string TName { get; set; }
        public int PCID { get; set; }
        public int UnitID { get; set; }
    }
}