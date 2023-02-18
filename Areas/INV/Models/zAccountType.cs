using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zAccountType", Schema = "DBO")]
    public class zAccountType
    {
        [Key]
        public int AccountTypeID { get; set; }
        public string AccountType { get; set; }
        public int? ParentID { get; set; }
    }
}