using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FosterCare;
using FosterCare.Areas.Admin.Data;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class DistrictMasterController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            return View(db.DistrictMasterTbls.Where(D=> D.IsActive == 1).ToList().OrderByDescending(d=> d.ID));
        }

        public ActionResult Create()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.Id, sb.StateName}), "Id", "StateName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistrictMasterTbl districtMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    districtMasterTbl.ID = (db.DistrictMasterTbls.Select(x => (long?)x.ID).Max() ?? 0) + 1;
                    districtMasterTbl.CreateDate = DateTime.Now;
                    districtMasterTbl.IsActive = 1;
                    db.DistrictMasterTbls.Add(districtMasterTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.Id, sb.StateName }), "Id", "StateName",districtMasterTbl.StateID);
                return View(districtMasterTbl);
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(long? id)
        {
            string[] SplitUrls = Request.RawUrl.Split('/');
            string CategorynQuery = "/" + SplitUrls[SplitUrls.Length - 4] + "/" + SplitUrls[SplitUrls.Length - 3] + "/" + SplitUrls[SplitUrls.Length - 2];
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), CategorynQuery))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMasterTbl districtMasterTbl = db.DistrictMasterTbls.Find(id);
            if (districtMasterTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.Id, sb.StateName }), "Id", "StateName", districtMasterTbl.StateID);
            return View(districtMasterTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DistrictName,CreateDate,ModifiedDate,IsActive")] DistrictMasterTbl districtMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    districtMasterTbl.ModifiedDate = DateTime.Now;
                    db.Entry(districtMasterTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.Id, sb.StateName }), "Id", "StateName", districtMasterTbl.StateID);
                return View(districtMasterTbl);
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
     
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            string[] SplitUrls = Request.RawUrl.Split('/');
            string CategorynQuery = "/" + SplitUrls[SplitUrls.Length - 4] + "/" + SplitUrls[SplitUrls.Length - 3] + "/" + SplitUrls[SplitUrls.Length - 2];
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), CategorynQuery))
            {
                TempData["FailMessage"] = "You are not authorized to delete this content";
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {
                string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update DistrictMasterTbl set IsActive='0',ModifiedDate='" + datenow + "' where ID = " + id + "");
                if (noOfRowUpdated == 0)
                {
                    TempData["FailMessage"] = "No Row Deleted";
                    return RedirectToAction("Index");
                }
                TempData["SuccessMessage"] = "Record Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
