﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("StockSetting", Schema = "dbo")]
    public class StockSetting
    {
        [Key]
        public int StockSettingID { get; set; }
        public double Quantity { get; set; }
        public double MinQuantity { get; set; }
        public int PTID { get; set; }
        public int StockTypeID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int CurrencyID { get; set; }
    }
}