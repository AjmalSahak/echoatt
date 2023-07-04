using AlphaTechMIS.Areas.INV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class CashManagmentController : Controller
    {
        // GET: INV/Cash
        INVDBContext db;
        public CashManagmentController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        //Pass parameter to handle cash-in and cash-out
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CashIn()
        {
            return View();
        }
        public ActionResult CashOut()
        {
            return View();

        }
        public ActionResult Expense()
        {
            return View();
        }
        public ActionResult GetChartOfAccount(int ParentID)
        {
            var data = db.ChartOfAccounts.Where(x => x.ParentID == ParentID).Select(e => new
            {
                e.CAID,
                Code = e.Code + "-" + e.Title
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartOfAccountByAccountType(int AccountTypeID)
        {
            var data = db.ChartOfAccounts.Where(x => x.AccountTypeID == AccountTypeID).Select(e => new
            {
                e.CAID,
                Code = e.Code + "-" + e.Title
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}