using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class StockSettingVM
    {
        public int StockSettingID { get; set; }
        public double Quantity { get; set; }
        public double MinQuantity { get; set; }
        public int PTID { get; set; }
        public int StockTypeID { get; set; }
        public System.DateTime LastAffectedDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int CurrencyID { get; set; }
        public string PName { get; set; }
        public string StockName { get; set; }
        public string CurrencyEnglish { get; set; }
    }
}