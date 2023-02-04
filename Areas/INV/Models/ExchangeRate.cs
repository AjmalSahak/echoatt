using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("ExchangeRate", Schema = "dbo")]
    public class ExchangeRate
    {
        [Key]
        public int ExchangeID { get; set; }
        public DateTime EDate { get; set; }
        public string D_EDate { get; set; }
        public int CurrencyID { get; set; }
        public double Amount { get; set; }
        public double ExRate { get; set; }
    }
}