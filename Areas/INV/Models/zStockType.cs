using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zStockType", Schema = "dbo")]
    public class zStockType
    {
        [Key]
        public int StockTypeID { get; set; }
        public string StockName { get; set; }
        public string StockCode { get; set; }
        public string Address { get; set; }

    }
}