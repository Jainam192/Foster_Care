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
    public class ParentMasterController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index(String search)
        {
            if (search != null)
            {
                string[] SplitUrls = Request.RawUrl.Split('?');
                string CategorynQuery = SplitUrls[SplitUrls.Length - 2];
                if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), CategorynQuery))
                {
                    TempData["FailMessage"] = "You are not authorized to View this Page";
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
                {
                    TempData["FailMessage"] = "You are not authorized to View this Page";
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            if (search != null && search != "")
            {
               
                var Parent = db.ParentMasterTbls.Where(g => (g.FosterFathersName.Contains(search) || g.ParentCode.Contains(search)) && g.IsActive == 1).ToList().OrderByDescending(p => p.ID);
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1 ).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");

                return View(Parent);
            }
            else
            {
                var childID = db.ChildParentConnectionTbls.Where(c => c.IsActive == 1 ).Select(c => c.ChildID).ToList();
                var parentdata = db.ParentMasterTbls.Where(p => p.IsActive == 1).Select(p => p.ID).ToList();
                ViewBag.ChildData = db.ChildParentConnectionTbls.Where(c => c.IsActive == 1).Select(c=> c.ChildMasterTbl.ChildName).ToList();

                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1 ).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");
                return View(db.ParentMasterTbls.Where(p => p.IsActive == 1).ToList().OrderByDescending(p => p.ID));
            }
        }

        public ActionResult Create()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            
            ViewBag.FosterParentDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParentMasterTbl parentMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    parentMasterTbl.ID = (db.ParentMasterTbls.Select(x => (long?)x.ID).Max() ?? 0) + 1;
                    parentMasterTbl.FosterParentSerialNumber = (db.ParentMasterTbls.Select(x => (long?)x.FosterParentSerialNumber).Max() ?? 0) + 1;
                    parentMasterTbl.CreateDate = DateTime.Now;
                    parentMasterTbl.IsActive = 1;
                    parentMasterTbl.UserID = long.Parse(Session["AdminID"].ToString());
                    db.ParentMasterTbls.Add(parentMasterTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
             
                ViewBag.FosterParentDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
                return View(parentMasterTbl);
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
            ParentMasterTbl parentMasterTbl = db.ParentMasterTbls.Find(id);
            if (parentMasterTbl == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.FosterParentDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName",parentMasterTbl.FosterParentDistrict);
            return View(parentMasterTbl);
        }
        [HttpPost]
        public ActionResult Edit(ParentMasterTbl parentMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    parentMasterTbl.ModifiedDate = DateTime.Now;
                    db.Entry(parentMasterTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
           
                ViewBag.FosterParentDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
                return View(parentMasterTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update ParentMasterTbl set IsActive='0',ModifiedDate='" + datenow + "' where ID = " + id + "");
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
        [ActionName("DeleteAssignChild")]
        public ActionResult DeleteAssignChild(long id)
        {
            string[] SplitUrls = Request.RawUrl.Split('/');
            string CategorynQuery = "/" + SplitUrls[SplitUrls.Length - 4] + "/" + SplitUrls[SplitUrls.Length - 3] + "/" + SplitUrls[SplitUrls.Length - 2];
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), CategorynQuery))
            {
                TempData["FailMessage"] = "You are not authorized to Unassign Child  ";
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {
                db.Database.ExecuteSqlCommand("Delete ChildParentConnectionTbl where Id=" + id);
                TempData["SuccessMessage"] = "Record Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult AssignChild(ChildParentConnectionTbl childParentConnectionTbl)
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to Assign Child";
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {               
                var childid = db.ChildParentConnectionTbls.Where(c => c.IsActive == 1 && c.ChildID == childParentConnectionTbl.ChildID).FirstOrDefault();
                if (childid!=null)
                {
                    TempData["FailMessage"] = "This Child Already Assigned";
                }
                else
                {
                    childParentConnectionTbl.CreateDate = DateTime.Now;
                    childParentConnectionTbl.IsActive = 1;
                    db.ChildParentConnectionTbls.Add(childParentConnectionTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                }

                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");
                
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
