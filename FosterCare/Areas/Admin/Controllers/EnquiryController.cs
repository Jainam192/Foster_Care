using FosterCare.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class EnquiryController : Controller
    {
        FosterCareDBEntities db = new FosterCareDBEntities();
        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            return View(db.EnquiryTbls.Where(e=> e.IsActive == 1).ToList().OrderByDescending(e=> e.ID));
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
                int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update EnquiryTbl set IsActive='0',ModifiedDate='" + datenow + "' where ID = " + id + "");
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
    }
}