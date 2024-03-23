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
    public class PotentialParentMastersController : Controller
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
                var name = db.PotentialParentMasters.Where(g => (g.ApplicantsName.Contains(search) || g.ContactNumber.Contains(search)) && g.IsActive == 1).ToList();
                return View(name);
            }
            else
            {
                return View(db.PotentialParentMasters.Where(p => p.IsActive == 1).ToList().OrderByDescending(p => p.ID));
            }
           
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
        public ActionResult Create(PotentialParentMaster potentialParentMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    potentialParentMaster.Age = Math.Round((double)potentialParentMaster.Age, 1);
                    potentialParentMaster.SerialNumber = (db.PotentialParentMasters.Select(x => (long?)x.SerialNumber).Max() ?? 0) + 1;
                    potentialParentMaster.CreateDate = DateTime.Now;
                    potentialParentMaster.IsActive = 1;
                    potentialParentMaster.UserID = long.Parse(Session["AdminID"].ToString());
                    db.PotentialParentMasters.Add(potentialParentMaster);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                return View(potentialParentMaster);
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
            PotentialParentMaster potentialParentMaster = db.PotentialParentMasters.Find(id);
            if (potentialParentMaster == null)
            {
                return HttpNotFound();
            }
            return View(potentialParentMaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PotentialParentMaster potentialParentMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    potentialParentMaster.Age = Math.Round((double)potentialParentMaster.Age, 1);
                    potentialParentMaster.ModifiedDate = DateTime.Now;
                    db.Entry(potentialParentMaster).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Update Successfully";
                    return RedirectToAction("Index");
                }
                return View(potentialParentMaster);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update PotentialParentMaster set IsActive='0',ModifiedDate='" + datenow + "' where ID = " + id + "");
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
