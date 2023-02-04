using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("Order", Schema = "dbo")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int DealerID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public bool IsProcessed { get; set; }
    }
}