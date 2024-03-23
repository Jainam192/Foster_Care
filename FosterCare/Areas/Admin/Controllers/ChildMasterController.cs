using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using FosterCare;
using FosterCare.Areas.Admin.Data;
using Newtonsoft.Json;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class ChildMasterController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
       

        public ActionResult Index(string search)
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
                var name = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => (g.ChildName.Contains(search) || g.ChildCode.Contains(search)) && g.IsActive == 1).ToList().OrderByDescending(c => c.ID);

                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(name);

            }
            else
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2);
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(childMasterTbls.Where(c => c.IsActive == 1).ToList().OrderByDescending(c => c.ID));
            }

        }

        public ActionResult Create()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.CCIMasterID = new SelectList(db.CCIMasterTbls.Where(c=> c.IsActive == 1), "ID", "InstitudeName");
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.PlacementDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.MonitoringDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            ViewBag.AddressDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName");
            //ViewBag.FosterParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildMasterTbl childMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    childMasterTbl.Age = Math.Round((double)childMasterTbl.Age, 1);
                    childMasterTbl.ID = (db.ChildMasterTbls.Select(x => (long?)x.ID).Max() ?? 0) + 1;
                    childMasterTbl.SerialNumber = (db.ChildMasterTbls.Select(x => (long?)x.SerialNumber).Max() ?? 0) + 1;
                    childMasterTbl.CreateDate = DateTime.Now;
                    childMasterTbl.IsActive = 1;
                    childMasterTbl.UserID = long.Parse(Session["AdminID"].ToString());
                    db.ChildMasterTbls.Add(childMasterTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.CCIMasterID = new SelectList(db.CCIMasterTbls.Where(c => c.IsActive == 1), "ID", "InstitudeName", childMasterTbl.CCIMasterID);
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.DistrictID);
                ViewBag.PlacementDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.PlacementDistrict);
                ViewBag.MonitoringDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.MonitoringDistrict);
       
                ViewBag.AddressDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName",childMasterTbl.AddressDistrict);
                return View(childMasterTbl);
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
            ChildMasterTbl childMasterTbl = db.ChildMasterTbls.Find(id);
            if (childMasterTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CCIMasterID = new SelectList(db.CCIMasterTbls.Where(c => c.IsActive == 1), "ID", "InstitudeName", childMasterTbl.CCIMasterID);
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.DistrictID);
            ViewBag.PlacementDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.PlacementDistrict);
            ViewBag.MonitoringDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.MonitoringDistrict);
           
            ViewBag.AddressDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.AddressDistrict);
            return View(childMasterTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChildMasterTbl childMasterTbl , ParentMasterTbl parentMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    childMasterTbl.Age = Math.Round((double)childMasterTbl.Age, 1);
                    childMasterTbl.ModifiedDate = DateTime.Now;
                    db.Entry(childMasterTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.CCIMasterID = new SelectList(db.CCIMasterTbls.Where(c => c.IsActive == 1), "ID", "InstitudeName", childMasterTbl.CCIMasterID);
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.DistrictID);
                ViewBag.PlacementDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.PlacementDistrict);
                ViewBag.MonitoringDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.MonitoringDistrict);
                
                ViewBag.AddressDistrict = new SelectList(db.DistrictMasterTbls.Where(c => c.IsActive == 1), "ID", "DistrictName", childMasterTbl.PlacementDistrict);
                return View(childMasterTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update ChildMasterTbl set IsActive='0',ModifiedDate='" + datenow + "' where ID = " + id + "");
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

        [HttpPost]
        public ActionResult AssignParent(ChildParentConnectionTbl childParentConnectionTbl)
            {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to Assign Parent";
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {
                var child = db.ChildParentConnectionTbls.Where(c => c.ChildID == childParentConnectionTbl.ChildID).Select(a => a.Id).FirstOrDefault();
                if(child != 0)
                {
                    var Parent = childParentConnectionTbl.ParentID;
                    string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update ChildParentConnectionTbl set ParentID = " + Parent + " , ModifiedDate = '" + datenow + "' where Id = " + child + "");
                }
                else
                {
                    childParentConnectionTbl.CreateDate = DateTime.Now;
                    childParentConnectionTbl.IsActive = 1;
                    db.ChildParentConnectionTbls.Add(childParentConnectionTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
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
