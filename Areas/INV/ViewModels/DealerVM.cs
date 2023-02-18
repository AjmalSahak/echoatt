using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class DealerVM
    {
        public int DealerID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public int CountryID { get; set; }
        public int ProvinceID { get; set; }
        public int TypeID { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
        public string Code { get; set; }
    }
}