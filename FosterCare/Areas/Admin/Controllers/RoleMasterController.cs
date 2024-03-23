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
    public class RoleMasterController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            return View(db.RoleMasterTbls.Where(r=> r.Isactive == 1).ToList().OrderByDescending(r=> r.Id));
        }

        public ActionResult Create()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleName,CreateDate,Isactive")] RoleMasterTbl roleMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    roleMasterTbl.CreateDate = DateTime.Now;
                    roleMasterTbl.Isactive = 1;
                    db.RoleMasterTbls.Add(roleMasterTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                return View(roleMasterTbl);
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
            RoleMasterTbl roleMasterTbl = db.RoleMasterTbls.Find(id);
            if (roleMasterTbl == null)
            {
                return HttpNotFound();
            }
            return View(roleMasterTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleName,CreateDate,Isactive")] RoleMasterTbl roleMasterTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(roleMasterTbl).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                return View(roleMasterTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update RoleMasterTbl set IsActive='0' where ID = " + id + "");
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
