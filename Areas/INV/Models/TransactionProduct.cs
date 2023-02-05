using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("TransactionProduct", Schema = "dbo")]
    public class TransactionProduct
    {
        [Key]
        public int TPID { get; set; }
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public double DiscountQuantity { get; set; }
        public int UnitID { get; set; }
    }
}