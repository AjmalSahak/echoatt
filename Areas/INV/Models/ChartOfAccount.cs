using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("ChartOfAccount", Schema = "dbo")]
    public class ChartOfAccount
    {
        [Key]
        public int CAID { get; set; }
        public string Code { get; set; }
        public string ENDescription { get; set; }
        public int? CurrencyID { get; set; }
        public int? ParentID { get; set; }
        public decimal? MaxLoan { get; set; }
        public int? DealerID { get; set; }
        public int? ProductID { get; set; }
        public int AccountTypeID { get; set; }
    }
}