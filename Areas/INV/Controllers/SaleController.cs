using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class SaleController : Controller
    {
        // GET: INV/Sale
        INVDBContext db;
        public SaleController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public string GenerateVoucherNumber()
        {
            string NumbersPart = "";
            int Counts = db.Database.SqlQuery<int>(@"SELECT count(*) AS TotalRecord FROM dbo.SaleTbl").Single();
            Counts = Counts + 1;
            if (Counts <= 9) { NumbersPart = "000000" + Counts; }
            else if (Counts > 9 && Counts <= 99) { NumbersPart = "00000" + Counts; }
            else if (Counts > 99 && Counts <= 999) { NumbersPart = "0000" + Counts; }
            else if (Counts > 999 && Counts <= 9999) { NumbersPart = "000" + Counts; }
            else if (Counts > 9999 && Counts <= 99999) { NumbersPart = "00" + Counts; }
            else if (Counts > 99999 && Counts <= 999999) { NumbersPart = "0" + Counts; }
            else { NumbersPart = Counts.ToString(); }

            string VoucherNumber = NumbersPart;
            return VoucherNumber;
        }
        [HttpPost]
        public ActionResult Create(SaleTbl NewRec)
        {
            var trans = db.Database.BeginTransaction();
            try
            {
                NewRec.CreatedOn = DateTime.Now;
                NewRec.IsReconciled = false;
                NewRec.InvoiceNo = "INV" + GenerateVoucherNumber();
                NewRec.CurrencyID = db.Dealers.Find(NewRec.DealerID).CurrencyID;
                db.SaleTbl.Add(NewRec);
                db.SaveChanges();

                string Tran_data = Request.Form["Tran_data"];
                dynamic TranJsonObj = JsonConvert.DeserializeObject(Tran_data);
                SaleDetail d = new SaleDetail();

                foreach (var obj in TranJsonObj)
                {
                    d.SaleID = NewRec.SaleID;
                    d.ProductID = obj.Products;
                    d.Quantity = obj.Quantities;
                    d.UnitPrice = obj.UnitPrices;
                    d.Discount_Type = obj.Discount_Types;
                    d.DiscountQuantity = obj.DiscountQuantitys;
                    d.TotalPrice = d.UnitPrice * Convert.ToDecimal(d.Quantity);
                    db.SaleDetail.Add(d);
                    db.SaveChanges();
                    var updateRec = db.StockSettings.Where(x => x.PTID == d.ProductID).FirstOrDefault();
                    if (updateRec != null)
                    {
                        updateRec.Quantity -= d.Quantity;
                    }
                    db.SaveChanges();

                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                string validationErrors = string.Join("<br /> ",
               ModelState.Values.Where(E => E.Errors.Count > 0)
                                .SelectMany(E => E.Errors)
                                .Select(E => E.ErrorMessage)
                              .ToArray());
                return Content(validationErrors + ex.Message + ex.InnerException, "text/html");

            }

            return Json("true", JsonRequestBehavior.AllowGet);


        }


        public ActionResult GetSales(int CustomerType)
        {
            var data = db.Database.SqlQuery<SaleVM>("EXEC DBO.GetSale {0}",CustomerType).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSaleDetail(int SaleID)
        {
            var data = db.Database.SqlQuery<SaleDetailVM>("EXEC DBO.GetSaleDetail {0}", SaleID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}