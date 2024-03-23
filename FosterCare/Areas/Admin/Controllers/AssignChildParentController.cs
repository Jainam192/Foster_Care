using FosterCare.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class AssignChildParentController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        public ActionResult Index()
        {
            ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");
            ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
            return View(db.ChildParentConnectionTbls.Where(c => c.IsActive == 1).ToList().OrderByDescending(c => c.Id));

        }
        [HttpPost]
        public ActionResult Index(long? ChildID, long? ParentID)
        {
             if (ChildID != null)
            {
                var childparentconnectionTbl = db.ChildParentConnectionTbls.Where(g => g.ChildID == ChildID && g.IsActive == 1).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode",ParentID);
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                return View(childparentconnectionTbl.OrderByDescending(c => c.Id));
            }
            else if (ParentID != null)
            {
                var childMasterTbls = db.ChildParentConnectionTbls.Where(g => g.ParentID == ParentID && g.IsActive == 1).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode", ParentID);
                return View(childMasterTbls.OrderByDescending(c => c.Id));
            }
            else
            {
                var childMasterTbls = db.ChildParentConnectionTbls.Where(g => g.IsActive == 1).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");

                return View(childMasterTbls.OrderByDescending(c => c.Id));

            }
        }
    }
}