using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("QuotationProduct", Schema = "dbo")]
    public class QuotationProduct
    {
        [Key]
        public int QPID { get; set; }
        public int QuotationID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
    }
}