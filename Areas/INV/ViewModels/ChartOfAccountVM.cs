using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class ChartOfAccountVM
    {
        public int CAID { get; set; }
        public int? AccountTypeID { get; set; }
        public string AccountType { get; set; }
        public string Code { get; set; }
        public string ENDescription { get; set; }

    }
    public class AccountTypeVM
    {
        public int AccountTypeID { get; set; }
        public string AccountType { get; set; }
        public int? ParentID { get; set; }
        public int? ATID { get; set; }
        public string TypeName { get; set; }
    }
}