using ClosedXML.Excel;
using FosterCare.Areas.Admin.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class ParentReportsController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        [ActionName("ExportToExcel")]
        public void ExportToExcel()
        {
            try
            {
                var Services = db.ParentMasterTbls.Where(u => u.IsActive == 1).Select(a => new {
                    a.ID,
                    a.UserID,
                    a.FosterParentSerialNumber,
                    FosterParentDistrict = a.DistrictMasterTbl.DistrictName,
                    a.ParentCode,
                    a.FosterMothersName,
                    a.FosterMothersDOB,
                    a.FosterMotherCurrentStatus,
                    a.FosterMotherHighestEducation,
                    a.FosterMotherEmploymentStatus,
                    a.FosterMotherIncome,
                    a.FosterFathersName,
                    a.FosterFathersDOB,
                    a.FosterFathersCurrentStatus,
                    a.FosterFathersHighestEducation,
                    a.FosterFathersEmploymentStatus,
                    a.FosterFathersIncome,
                    a.Address,
                    a.ContactNumber,
                    a.FosterGirlsCount,
                    a.FosterBoysCount,
                    a.RationCardFosterChildrenCount,
                    a.AnyOtherFosters,
                    a.ChildSheetFosteredChildrenCount,
                    a.AdoptedChildrenCount,
                    a.BiologicalChildrenCount,
                    a.PlacementDate,
                    a.ReasonForFostering,
                    a.LastExtensionDate,
                    a.ExtensionPeriod,
                    a.TerminationDate,
                    a.ReasonForTermination,
                    a.LastFollowUpDate,
                    a.CreateDate,
                    a.ModifiedDate
                }).ToList();
                DataTable dt = new DataTable();
                string json = JsonConvert.SerializeObject(Services);
                dt = JsonConvert.DeserializeObject<System.Data.DataTable>(json);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "ParentReport");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "ParentReport" + DateTime.Now.ToString("dd-MMM-yyyy") + ".xlsx";
                    Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;

            }
        }
        public ActionResult Index()
        {
            if (!Authentication.Permission(long.Parse(Session["RoleID"].ToString()), Request.RawUrl))
            {
                TempData["FailMessage"] = "You are not authorized to View this Page";
                return RedirectToAction("Index", "Dashboard");
            }
            var parentMasterTbls = db.ParentMasterTbls.Where(c => c.IsActive == 1).ToList().OrderByDescending(c => c.ID);
            ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName").ToList();
            return View(parentMasterTbls);
        }

        [HttpPost]
        public ActionResult Index(DateTime? FromDate, DateTime? ToDate, long? ParentID , long? DistrictID)
        {
            if (FromDate != null && ToDate != null && ParentID != null)
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.ID == ParentID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(parentMasterTbls.OrderByDescending(c => c.ID));
            }
            else if (FromDate != null && ToDate != null && DistrictID != null)
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.FosterParentDistrict == DistrictID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(parentMasterTbls.OrderByDescending(c => c.ID));
            }
            else if (ParentID != null)
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.ID == ParentID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(parentMasterTbls.OrderByDescending(c => c.ID));
            }
            else if (DistrictID != null)
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.FosterParentDistrict == DistrictID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(parentMasterTbls.OrderByDescending(c => c.ID));
            }
            if (FromDate != null && ToDate != null)
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");
                return View(parentMasterTbls.OrderByDescending(c => c.ID));
            }
            else
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(g => g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ParentID = new SelectList(db.ParentMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ParentCode = sb.FosterFathersName + " (" + sb.ParentCode + ")" }), "ID", "ParentCode");

                return View(parentMasterTbls.OrderByDescending(c => c.ID));

            }
        }
    }
}