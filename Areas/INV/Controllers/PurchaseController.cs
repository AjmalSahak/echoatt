using AlphaTechMIS.Areas.INV.Data;
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
    public class PurchaseController : Controller
    {
        // GET: INV/Purchase
        INVDBContext db;
        public PurchaseController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PurchaseTbl NewRec)
        {
            var trans = db.Database.BeginTransaction();
            try
            {
                var dealer = db.Dealers.Find(NewRec.DealerID);
                var latestExchangeRate = db.ExchangeRates
                                        .Where(x => x.CurrencyID == dealer.CurrencyID)
                                        .OrderByDescending(x => x.ExchangeID)
                                        .FirstOrDefault();

                if (latestExchangeRate != null)
                {
                    NewRec.ExchangeRate = Convert.ToDouble(latestExchangeRate.ExRate);
                }
                else
                {
                    NewRec.ExchangeRate = 0.00; // need to be change
                }

                NewRec.CreatedOn = DateTime.Now;
                NewRec.IsReconciled = false;
                db.PurchaseTbl.Add(NewRec);
                db.SaveChanges();

                string Tran_data = Request.Form["Tran_data"];
                dynamic TranJsonObj = JsonConvert.DeserializeObject(Tran_data);
                PurchaseDetail d = new PurchaseDetail();

                foreach (var obj in TranJsonObj)
                {
                    d.PurchaseID = NewRec.PurchaseID;
                    d.ProductID = obj.Products;
                    d.Quantity = obj.Quantities;
                    d.UnitPrice = obj.UnitPrices;
                    d.TotalPrice = d.UnitPrice *Convert.ToDecimal( d.Quantity);
                    db.PurchaseDetail.Add(d);
                    db.SaveChanges();
                    var p = db.zProducts.Find(d.ProductID);
                    p.DefualtPurchasePrice = d.UnitPrice;
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

        public ActionResult GetPurchase()
        {
            var data = db.Database.SqlQuery<PurchaseVM>("EXEC DBO.GetPurchase").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPurchaseDetail(int PurchaseID)
        {
            var data = db.Database.SqlQuery<PurchaseDetailVM>("EXEC DBO.GetPurchaseDetail {0}",PurchaseID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDealer(int TypeID)
        {
            var data = db.Database.SqlQuery<DealerVM>("EXEC DBO.GetDealer {0}", TypeID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CurrencyList()
        {
            return Json(db.zCurrencys.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDealerCurrency(int DealerID)
        {
            var data = db.Database.SqlQuery<zCurrency>(@"SELECT * FROM DBO.zCurrency C 
WHERE C.CurrencyID=(SELECT D.CurrencyID FROM DBO.Dealer D WHERE D.DealerID={0})", DealerID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}