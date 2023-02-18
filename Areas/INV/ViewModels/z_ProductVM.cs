using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class z_ProductVM
    {
        public int ProductID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public string Description { get; set; }
        public int PTID { get; set; }
        public int PCID { get; set; }
        public string Image { get; set; }
        public string TName { get; set; }
        public string UnitName { get; set; }
        public string Category { get; set; }
    }
    public class z_ProductListVM
    {
        public int PTID { get; set; }
        public string TName { get; set; }
        public int PCID { get; set; }
        public int UnitID { get; set; }
        public string Category { get; set; }
        public string UnitName { get; set; }
    }
}