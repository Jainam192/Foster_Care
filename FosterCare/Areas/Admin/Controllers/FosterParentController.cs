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
    public class FosterParentController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index()
        {
            var fosterParentTbls = db.FosterParentTbls.Where(c=> c.IsActive == 1).Include(f => f.StateMasterTbl);
            return View(fosterParentTbls.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.State = new SelectList(db.StateMasterTbls.Where(c=> c.IsActive ==1), "Id", "StateName");
            ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FosterParentTbl fosterParentTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    fosterParentTbl.CreateDate = DateTime.Now;
                    fosterParentTbl.IsActive = 1;
                    db.FosterParentTbls.Add(fosterParentTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }

                ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", fosterParentTbl.State);
                ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", fosterParentTbl.District);
                return View(fosterParentTbl);
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
            FosterParentTbl fosterParentTbl = db.FosterParentTbls.Find(id);
            if (fosterParentTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", fosterParentTbl.State);
            ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName",fosterParentTbl.District);
            return View(fosterParentTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FosterParentTbl fosterParentTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fosterParentTbl.ModifiedDate = DateTime.Now;
                    db.Entry(fosterParentTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", fosterParentTbl.State);
                ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", fosterParentTbl.District);
                return View(fosterParentTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update FosterParentTbl set IsActive='0' where ID = " + id + "");
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
