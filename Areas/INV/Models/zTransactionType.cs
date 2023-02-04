using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zTransactionType", Schema = "dbo")]
    public class zTransactionType
    {
        [Key]
        public int TransactionTypeID { get; set; }
        public string TransactionType { get; set; }

    }
}