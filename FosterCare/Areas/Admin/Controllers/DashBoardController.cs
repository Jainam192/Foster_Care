using FosterCare.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class DashBoardController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();

        public ActionResult permission(int? UserId)
        {
            long? RoleId = db.AdminLoginTbls.Where(u => u.Id == UserId).Select(u => u.Role).FirstOrDefault();
            var permissions = db.PermissionMasterTbls.Where(p => p.RoleID == RoleId).Select(p => new { p.ModuleMasterTbl.ModuleName, p.ModuleMasterTbl.URL }).ToList();
            return Json(permissions, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            ViewBag.ChildReports = db.ChildMasterTbls.Where(c => c.IsActive == 1).Count();
            ViewBag.ParentReports = db.ParentMasterTbls.Where(c => c.IsActive == 1).Count();
            ViewBag.potentialParentReports = db.PotentialParentMasters.Where(c => c.IsActive == 1).Count();
            ViewBag.User = db.AdminLoginTbls.Where(c => c.IsActive == 1).Count();
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1 && sb.StateID == null).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(long? DistrictID)
        {
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1 && sb.StateID == null).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName").ToList();

            #region ParentsEmployment
            ViewBag.FEmploymentSelf = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterFathersEmploymentStatus == "Self" && c.FosterParentDistrict == DistrictID).Count();
            ViewBag.FEmploymentPrivate = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterFathersEmploymentStatus == "Private" && c.FosterParentDistrict == DistrictID).Count();
            ViewBag.FEmploymentGovt = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterFathersEmploymentStatus == "Govt" && c.FosterParentDistrict == DistrictID).Count();
            ViewBag.MEmploymentSelf = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterMotherEmploymentStatus == "Self" && c.FosterParentDistrict == DistrictID).Count();
            ViewBag.MEmploymentPrivate = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterMotherEmploymentStatus == "Private" && c.FosterParentDistrict == DistrictID).Count();
            ViewBag.MEmploymentGovt = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.FosterMotherEmploymentStatus == "Govt" && c.FosterParentDistrict == DistrictID).Count();
            #endregion

            #region Parents' Income ( in lakhs )
            ViewBag.FIncome0_6 = db.ParentMasterTbls.Where(c => c.IsActive == 1);
            #endregion

            return View();
        }

            public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}