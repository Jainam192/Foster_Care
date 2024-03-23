using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FosterCare;

namespace FosterCare.Areas.Admin.Controllers
{
    public class ChildInstitutionController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index()
        {
            var childInstitutionTbls = db.ChildInstitutionTbls.Where(c=> c.IsActive ==1).Include(c => c.ChildCategoryTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.StateMasterTbl).Include(c => c.StateMasterTbl1).Include(c => c.TehsilMasterTbl).Include(c => c.TehsilMasterTbl1);
            return View(childInstitutionTbls.ToList());
        }
        [HttpPost]
        [ActionName("GetDistrictByState")]
        public ActionResult GetDistrictByState(long? StateID)
        {
            try
            {
                var DistrictName = new SelectList(db.DistrictMasterTbls.Where(bm => bm.StateID == StateID && bm.IsActive == 1).Select(bm => new { bm.ID, bm.DistrictName }), "Id", "DistrictName");
                return Json(DistrictName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ActionName("GetTehsilByDistrict")]
        public ActionResult GetTehsilByDistrict(long? DistrictID)
        {
            try
            {
                var TehsilName = new SelectList(db.TehsilMasterTbls.Where(bm => bm.DistrictID== DistrictID && bm.IsActive == 1).Select(bm => new { bm.ID, bm.TehsilName}), "Id", "TehsilName");
                return Json(TehsilName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            ViewBag.CategoryOfChild = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory");
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.ChildDistrictId = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName");
            ViewBag.ChildStateId = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName");
            ViewBag.TehsilID = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName");
            ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildInstitutionTbl childInstitutionTbl,HttpPostedFileBase ChildImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string nowdatetime = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute;
                    childInstitutionTbl.ChildImage= "/Files/ChildImage/" + nowdatetime + Path.GetFileName(ChildImage.FileName);
                    ChildImage.SaveAs(Server.MapPath("~" + childInstitutionTbl.ChildImage));
                    childInstitutionTbl.CreateDate = DateTime.Now;
                    childInstitutionTbl.IsActive = 1;
                    db.ChildInstitutionTbls.Add(childInstitutionTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.CategoryOfChild = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childInstitutionTbl.CategoryOfChild);
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.DistrictID);
                ViewBag.ChildDistrictId = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.ChildDistrictId);
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.StateID);
                ViewBag.ChildStateId = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.ChildStateId);
                ViewBag.TehsilID = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.TehsilID);
                ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.ChildTehsil);
                return View(childInstitutionTbl);
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
            ChildInstitutionTbl childInstitutionTbl = db.ChildInstitutionTbls.Find(id);
            if (childInstitutionTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryOfChild = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childInstitutionTbl.CategoryOfChild);
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.DistrictID);
            ViewBag.ChildDistrictId = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.ChildDistrictId);
            ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.StateID);
            ViewBag.ChildStateId = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.ChildStateId);
            ViewBag.TehsilID = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.TehsilID);
            ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.ChildTehsil);
            return View(childInstitutionTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChildInstitutionTbl childInstitutionTbl,HttpPostedFileBase ChildImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ChildImage != null)
                    {
                        string nowdatetime = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute;

                        childInstitutionTbl.ChildImage= "/Files/ChildImage/" + nowdatetime + Path.GetFileName(childInstitutionTbl.ChildImage);
                        ChildImage.SaveAs(Server.MapPath("~" + childInstitutionTbl.ChildImage));
                    }

                    db.Entry(childInstitutionTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryOfChild = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childInstitutionTbl.CategoryOfChild);
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.DistrictID);
                ViewBag.ChildDistrictId = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childInstitutionTbl.ChildDistrictId);
                ViewBag.StateID = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.StateID);
                ViewBag.ChildStateId = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childInstitutionTbl.ChildStateId);
                ViewBag.TehsilID = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.TehsilID);
                ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childInstitutionTbl.ChildTehsil);
                return View(childInstitutionTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update ChildInstitutionTbl set IsActive='0'where Id = " + id + "");
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
