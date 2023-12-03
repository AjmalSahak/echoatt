using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class ExchangeRateController : Controller
    {
        // GET: INV/ExchangeRate
        INVDBContext db;
        public ExchangeRateController()
        {
            db = new INVDBContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult findExRate(int DealerID)
        {
            var data = db.Database.SqlQuery<ExRateVM>("EXEC DBO.GetExRateByDealer {0}",DealerID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCurrencyList()
        {
            var data = db.zCurrencys.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(ExchangeRate NewRec)
        {
            NewRec.EDate = DateTime.Now;
            db.ExchangeRates.Add(NewRec);
            db.SaveChanges();
            return Json("Record_Saved");
        }
        [HttpPost]
        public ActionResult Edit(ExchangeRate InputRec)
        {
            ExchangeRate FoundRec = db.ExchangeRates.Find(InputRec.ExchangeID);
            FoundRec.CurrencyID = InputRec.CurrencyID;
            FoundRec.Amount = InputRec.Amount;
            FoundRec.ExRate = InputRec.ExRate;
            db.SaveChanges();
            return Json("Record_Update");
        }
        public ActionResult GetExchangeList()
        {
            var data = db.Database.SqlQuery<ExchangeRateVM>("EXEC DBO.GetExchangeList").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}