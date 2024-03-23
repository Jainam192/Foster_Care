using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FosterCare;
using FosterCare.Areas.Admin.Data;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class ManageUserController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
           
            return View(db.AdminLoginTbls.Where(a=> a.IsActive == 1).ToList().OrderByDescending(c=> c.Id));
        }

        public ActionResult Create()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Role = new SelectList(db.RoleMasterTbls.Where(c => c.Isactive == 1), "ID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,ContactNumber,Password,Role,IsActive")] AdminLoginTbl adminLoginTbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    byte[] ePass;
                    UTF8Encoding encoder = new UTF8Encoding();
                    ePass = md5Hasher.ComputeHash(encoder.GetBytes(adminLoginTbl.Password));
                    String oldPassword = Convert.ToBase64String(ePass);
                    adminLoginTbl.Password = oldPassword;
                    adminLoginTbl.Id = (db.AdminLoginTbls.Select(x => (long?)x.Id).Max() ?? 0) + 1;
                    adminLoginTbl.IsActive = 1;
                    db.AdminLoginTbls.Add(adminLoginTbl);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                    return RedirectToAction("Index");

                }
                ViewBag.Role = new SelectList(db.RoleMasterTbls.Where(c => c.Isactive == 1), "ID", "RoleName");
                return View(adminLoginTbl);
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update AdminLoginTbl set IsActive='0' where ID = " + id + "");
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
        [ActionName("ChangePassword")]
        public ActionResult ChangePassword(AdminLoginTbl adminLoginTbl)
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to Change Password";
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {
                if (ModelState.IsValid)
                {

                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    byte[] ePass;
                    UTF8Encoding encoder = new UTF8Encoding();
                    ePass = md5Hasher.ComputeHash(encoder.GetBytes(adminLoginTbl.Password));
                    String pass = Convert.ToBase64String(ePass);
                    int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update AdminLoginTbl set Password='" + pass + "' where Id = " + adminLoginTbl.Id + "");
                    if (noOfRowUpdated == 0)
                    {
                        TempData["FailMessage"] = "Password Not Changed";
                        return RedirectToAction("Index");
                    }
                    TempData["SuccessMessage"] = "Password Changed Successfully";
                    return RedirectToAction("Index");
                }
                return View(adminLoginTbl);
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
