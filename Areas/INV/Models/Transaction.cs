using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("Transaction", Schema = "dbo")]
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int TypeID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime EDate { get; set; }
        public string D_EDate { get; set; }
        public int DealerID { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int RefrenceID { get; set; }
        public bool IsReconciled { get; set; }
    }
}