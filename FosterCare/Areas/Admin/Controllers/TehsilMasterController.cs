using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FosterCare;

namespace FosterCare.Areas.Admin.Controllers
{
    public class TehsilMasterController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index()
        {
            var tehsilMasterTbls = db.TehsilMasterTbls.Where(c=> c.IsActive == 1).Include(t => t.DistrictMasterTbl).Include(t => t.StateMasterTbl);
            return View(tehsilMasterTbls.ToList());
        }
        [HttpPost]
        [ActionName("GetDistrictByState")]
        public ActionResult GetDistrictByState(long? StateID)
        {
            try
            {
                var DistrictName = new SelectList(db.DistrictMasterTbls.Where(bm => bm.StateID == StateID && bm.IsActive == 1).Select(bm => new { bm.ID, bm.DistrictName}), "Id", "DistrictName");
                return Json(DistrictName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TehsilMasterTbl tehsilMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    tehsilMasterTbl.CreateDate = DateTime.Now;
                    tehsilMasterTbl.IsActive = 1;
                    db.TehsilMasterTbls.Add(tehsilMasterTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", tehsilMasterTbl.DistrictID);
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", tehsilMasterTbl.StateID);
                return View(tehsilMasterTbl);
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TehsilMasterTbl tehsilMasterTbl = db.TehsilMasterTbls.Find(id);
            if (tehsilMasterTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", tehsilMasterTbl.DistrictID);
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", tehsilMasterTbl.StateID);
            return View(tehsilMasterTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TehsilMasterTbl tehsilMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tehsilMasterTbl.ModifiedDate = DateTime.Now;
                    db.Entry(tehsilMasterTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", tehsilMasterTbl.DistrictID);
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", tehsilMasterTbl.StateID);
                return View(tehsilMasterTbl);
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
            try
            {
                string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update TehsilMaster set IsActive='0' where ID = " + id + "");
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
