using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class ChartOfAccountController : Controller
    {
        // GET: INV/ChartOfAccount
        INVDBContext db;
        public ChartOfAccountController()
        {
            db = new INVDBContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public string GetAccountTypes()
        {
            string depts = "";
            var data = db.Database.SqlQuery<AccountTypeVM>("SELECT * FROM DBO.zAccountType").ToList();
            depts = GenerateListDept(data);
            return depts;
        }
        public string GenerateListDept(List<AccountTypeVM> deptItems, int pId = 0)
        {
            string depts = "";
            int ulStart = 0;
            foreach (var row in deptItems)
            {
                if (Convert.ToInt32(row.ParentID) == pId)
                {
                    if (ulStart == 0)
                    {
                        depts += "<UL id='ul-data'>";
                        ulStart++;
                    }

                    string url = row.AccountTypeID.ToString();

                    depts += "<LI title='" + row.AccountTypeID + "'><a href='#'>" + row.AccountType + "</a>" + GenerateListDept(deptItems, row.AccountTypeID) + "</LI>";

                }

            }
            if (ulStart != 0) { depts += "</UL>"; }

            return depts;
        }

        public ActionResult GetChartAccounts()
        {
            var data = db.Database.SqlQuery<ChartOfAccountVM>(@"EXEC DBO.GetChartOfAccount").ToList();
            var jsondata = Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }

        [HttpPost]
        public ActionResult DeleteChartofAccount(int CAID)
        {

            try
            {
                int checkChartofAccount = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM dbo.TransactionDetail WHERE CAID = {0}", CAID).Single();
                if (checkChartofAccount > 0)
                {
                    return Json("This Chart of Account has  A journal Entry, Can't be deleted");
                }

                else
                {
                    var data = db.ChartOfAccounts.Find(CAID);
                    db.ChartOfAccounts.Remove(data);
                    db.SaveChanges();
                    return Json("true");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Create(ChartOfAccount model)
        {
            if (ModelState.IsValid)
            {
                db.ChartOfAccounts.Add(model);
                db.SaveChanges();

                return Json("true");
            }
            else
            {
                return Json("false");

            }
        }
        [HttpPost]
        public ActionResult Update(ChartOfAccount model)
        {
            if (ModelState.IsValid)
            {
                var data = db.ChartOfAccounts.Find(model.CAID);
                data.AccountTypeID = model.AccountTypeID;
                data.Code = model.Code;
                data.ENDescription = model.ENDescription;

                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json("Updated");
            }
            else
            {
                return Json("false");
            }


        }

    }
}
