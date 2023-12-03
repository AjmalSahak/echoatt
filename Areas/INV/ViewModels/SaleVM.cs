using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.ViewModels
{
    public class SaleVM
    {
        public int SaleID { get; set; }
        public DateTime EDate { get; set; }
        public string D_EDate { get; set; }
        public int DealerID { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsReconciled { get; set; }
        public double ExchangeRate { get; set; }
        public string DelearName { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string InvoiceNo { get; set; }
    }
    public class SaleDetailVM
    {
        public int SlDetailID { get; set; }
        public int ProductID { get; set; }
        public string PName { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Discount_Type { get; set; }
        public double DiscountQuantity { get; set; }
        public int SaleID { get; set; }
    }
}