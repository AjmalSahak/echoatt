using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zCurrency", Schema = "dbo")]
    public class zCurrency
    {
        [Key]
        public int CurrencyID { get; set; }
        public string CurrencyEnglish { get; set; }
        public string CurrencyDari { get; set; }
        public string CurrencyPashto { get; set; }
        public string ConversionOperator { get; set; }

    }
}