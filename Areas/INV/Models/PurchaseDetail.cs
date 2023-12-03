using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("PurchaseDetail", Schema = "dbo")]

    public class PurchaseDetail
    {
        [Key]
        public int PrDetailID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int PurchaseID { get; set; }
    }
}