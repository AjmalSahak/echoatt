using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("z_Unit", Schema = "dbo")]
    public class z_Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitName { get; set; }
    }
}