﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("TransactionDetail", Schema = "dbo")]
    public class TransactionDetail
    {
        [Key]
        public int TDID { get; set; }
        public int TransactionID { get; set; }
        public int? CAID { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyID { get; set; }
        public int TransactionTypeID { get; set; }
        public string Remarks { get; set; }
    }
}