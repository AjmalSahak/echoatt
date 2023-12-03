using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zProduct", Schema = "dbo")]
    public class zProduct
    {
        [Key]
        public int ProductID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public decimal DefualtPurchasePrice { get; set; }
        public decimal DefualtSalePrice { get; set; }
        public string Description { get; set; }
        public int PTID { get; set; }
        public string Image { get; set; }
    }
}