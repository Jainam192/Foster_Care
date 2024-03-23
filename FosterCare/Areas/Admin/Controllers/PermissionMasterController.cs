using FosterCare.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class PermissionMasterController : Controller
    {
        FosterCareDBEntities db = new FosterCareDBEntities();
        public ActionResult getModule(int RoleId)
        {
            long?[] moduleArray = db.PermissionMasterTbls.Where(p => p.RoleID == RoleId).Select(p => p.ModuleID).ToArray();
            List<SelectListItem> names = new List<SelectListItem>();
            foreach (var module in db.ModuleMasterTbls.Where(m=> m.IsActive == 1))
            {
                if (Array.IndexOf(moduleArray, module.Id) != -1)
                {
                    names.Add(new SelectListItem { Text = module.ModuleName, Value = module.Id.ToString(), Selected = true });
                    continue;
                }
                names.Add(new SelectListItem { Text = module.ModuleName, Value = module.Id.ToString() });
            }
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            List<SelectListItem> names = new List<SelectListItem>();
            foreach (var i in db.ModuleMasterTbls)
            {
                names.Add(new SelectListItem { Text = i.ModuleName, Value = i.Id.ToString() });
            }
            ViewBag.RoleID = new SelectList(db.RoleMasterTbls, "Id", "RoleName");
            return View(names);
        }

        [HttpPost]
        public ActionResult Index(int RoleId, IEnumerable<int> names)
        {
            try
            {
                ViewBag.RoleID = new SelectList(db.RoleMasterTbls, "Id", "RoleName");
                db.Database.ExecuteSqlCommand("Delete PermissionMasterTbl where RoleId=" + RoleId);
                if(names !=null)
                {
                    foreach (int item in names)
                    {
                        PermissionMasterTbl permission = new PermissionMasterTbl();
                        permission.RoleID = RoleId;
                        permission.ModuleID = item;
                        permission.IsActive = 1;
                        db.PermissionMasterTbls.Add(permission);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return View(names);
            }
            return View(names);
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