using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class ExchangeRateVM
    {
        public int ExchangeID { get; set; }
        public DateTime? EDate { get; set; }
        public string D_EDate { get; set; }
        public int CurrencyID { get; set; }
        public decimal Amount { get; set; }
        public double ExRate { get; set; }
        public decimal AFNAmount { get; set; }
        public string CurrencyEnglish { get; set; }
        public string ConversionOperator { get; set; }
    }
    public class ExRateVM
    {
        public int ExchangeID { get; set; }
        public int CurrencyID { get; set; }
        public decimal? Amount { get; set; }
        public double? ExRate { get; set; }

    }
}