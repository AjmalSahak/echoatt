using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("QuotationDetail", Schema = "dbo")]
    public class QuotationDetail
    {
        [Key]
        public int QDID { get; set; }
        public int QuotationID { get; set; }
        public int CurrencyID { get; set; }
        public double Amount { get; set; }
        public double ExRate { get; set; }
    }
}