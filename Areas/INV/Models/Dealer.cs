using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("Dealer", Schema = "dbo")]
    public class Dealer
    {
        [Key]
        public int DealerID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public int CountryID { get; set; }
        public int ProvinceID { get; set; }
        public int TypeID { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
    }
}