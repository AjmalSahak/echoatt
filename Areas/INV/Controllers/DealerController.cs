using AlphaTechMIS.Areas.INV.Models;
using AlphaTechMIS.Areas.INV.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaTechMIS.Areas.INV.Controllers
{
    public class DealerController : Controller
    {
        // GET: INV/Dealer
        INVDBContext db;
        public DealerController()
        {
            db = new INVDBContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index(int TypeID)
        {
            if (TypeID == 1)
                ViewBag.Type = "Customer";
            else if (TypeID == 2)
                ViewBag.Type = "Vendor";

            ViewBag.CountryID = new SelectList(db.zCountrys, "CountryID", "CountryNameEn");
            ViewBag.ProvinceID = new SelectList(db.zProvinces, "ProvinceID", "PName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Dealer v)
        {
            if (db.Dealers.Where(x => x.Name.ToLower() == v.Name.ToLower() && x.CurrencyID == v.CurrencyID && x.ContactNo == v.ContactNo).Count() > 0)
                return Json("Account Already Exist");
            if (ModelState.IsValid)
            {

                using (var t = db.Database.BeginTransaction())
                {
                    try
                    {
                        HttpPostedFileBase Doc = Request.Files["Attachment"];
                        string fullFileName = null;
                        if (Doc != null && Doc.FileName != "")
                        {
                            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Doc.FileName);
                            var extension = Path.GetExtension(Doc.FileName).ToLower();
                            if (extension != ".pdf" && extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                                return Json("FileFormatError");
                            if (Doc.ContentLength > 2097152)
                                return Json("FileSizeError");
                            string TimeStamp = DateTime.Now.ToString("yyyMMddHmmss");
                            fullFileName = fileNameWithoutExtension + "_" + TimeStamp + extension;
                            v.Attachment = "/Uploads/Dealer/" + fullFileName;
                            string filePath = Path.Combine(Server.MapPath("~/Uploads/Dealer"), fullFileName);
                            Doc.SaveAs(filePath);
                        }
                        if (v.Remarks == "Customer")
                            v.TypeID = 1;
                        else v.TypeID = 2;
                        db.Dealers.Add(v);
                        db.SaveChanges();

                        t.Commit();
                        return Json("saved");
                    }
                    catch (Exception ex)
                    {
                        t.Rollback();
                        return Json("error" + ex.Message + "-" + ex.InnerException);
                    }
                };
            }
            string validationErrors = string.Join("<br /> ",
                     ModelState.Values.Where(E => E.Errors.Count > 0)
                                .SelectMany(E => E.Errors)
                                .Select(E => E.ErrorMessage)
                              .ToArray());
            return Content(validationErrors, "text/html");
        }

        public ActionResult DealerList(string Type)
        {
            var data = db.Database.SqlQuery<DealerVM>("EXEC DBO.DealerList {0}", Type).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}