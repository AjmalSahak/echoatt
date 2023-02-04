using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zDealType", Schema = "dbo")]
    public class zDealType
    {
        [Key]
        public int DealID { get; set; }
        public string DealName { get; set; }

    }
}