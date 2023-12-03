using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("SaleDetail", Schema = "dbo")]

    public class SaleDetail
    {
        [Key]
        public int SlDetailID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Discount_Type { get; set; }
        public double DiscountQuantity { get; set; }
        public int SaleID { get; set; }
    }
}