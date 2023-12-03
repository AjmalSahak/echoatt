using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("SaleTbl", Schema = "dbo")]

    public class SaleTbl
    {
        [Key]
        public int SaleID { get; set; }
        public DateTime EDate { get; set; }
        public string D_EDate { get; set; }
        public int DealerID { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsReconciled { get; set; }
        public int CurrencyID { get; set; }
        public double ExchangeRate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string InvoiceNo { get; set; }
    }
}