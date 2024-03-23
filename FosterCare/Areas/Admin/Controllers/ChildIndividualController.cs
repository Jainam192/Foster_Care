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
    public class ChildIndividualController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index()
        {
            var childIndividualTbls = db.ChildIndividualTbls.Where(c=> c.IsActive == 1).Include(c => c.ChildCategoryTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.StateMasterTbl).Include(c => c.StateMasterTbl1).Include(c => c.TehsilMasterTbl).Include(c => c.TehsilMasterTbl1);
            return View(childIndividualTbls.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ChildCategory = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory");
            ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.ChildDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName");
            ViewBag.ChildState = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName");
            ViewBag.Tehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName");
            ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildIndividualTbl childIndividualTbl,HttpPostedFileBase ChildImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string nowdatetime = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute;
                    childIndividualTbl.ChildImage = "/Files/ChildIndividual/" + nowdatetime + Path.GetFileName(ChildImage.FileName);
                    ChildImage.SaveAs(Server.MapPath("~" + childIndividualTbl.ChildImage));
                    childIndividualTbl.CreateDate = DateTime.Now;
                    childIndividualTbl.IsActive = 1;
                    db.ChildIndividualTbls.Add(childIndividualTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.ChildCategory = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childIndividualTbl.ChildCategory);
                ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.District);
                ViewBag.ChildDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.ChildDistrict);
                ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.State);
                ViewBag.ChildState = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.ChildState);
                ViewBag.Tehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.Tehsil);
                ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.ChildTehsil);
                return View(childIndividualTbl);
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
            ChildIndividualTbl childIndividualTbl = db.ChildIndividualTbls.Find(id);
            if (childIndividualTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildCategory = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childIndividualTbl.ChildCategory);
            ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.District);
            ViewBag.ChildDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.ChildDistrict);
            ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.State);
            ViewBag.ChildState = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.ChildState);
            ViewBag.Tehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.Tehsil);
            ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.ChildTehsil);
            return View(childIndividualTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChildIndividualTbl childIndividualTbl,HttpPostedFileBase ChildImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ChildImage != null)
                    {
                        string nowdatetime = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute;

                        childIndividualTbl.ChildImage = "/Files/ChildIndividual/" + nowdatetime + Path.GetFileName(childIndividualTbl.ChildImage);
                        ChildImage.SaveAs(Server.MapPath("~" + childIndividualTbl.ChildImage));
                    }

                    db.Entry(childIndividualTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.ChildCategory = new SelectList(db.ChildCategoryTbls.Where(c => c.IsActive == 1), "Id", "ChildCategory", childIndividualTbl.ChildCategory);
                ViewBag.District = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.District);
                ViewBag.ChildDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childIndividualTbl.ChildDistrict);
                ViewBag.State = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.State);
                ViewBag.ChildState = new SelectList(db.StateMasterTbls.Where(c => c.IsActive == 1), "Id", "StateName", childIndividualTbl.ChildState);
                ViewBag.Tehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.Tehsil);
                ViewBag.ChildTehsil = new SelectList(db.TehsilMasterTbls.Where(c => c.IsActive == 1), "ID", "TehsilName", childIndividualTbl.ChildTehsil);
                return View(childIndividualTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update ChildIndividualTbl set IsActive='0'where Id = " + id + "");
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
