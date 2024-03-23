using FosterCare.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FosterCare;
using System.IO;
using ClosedXML.Excel;
using Newtonsoft.Json;

namespace FosterCare.Areas.Admin.Controllers
{
    [AdminSessionCheck]
    public class ChildReportsController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        [ActionName("ExportToExcel")]
        public void ExportToExcel()
        {
            try
            {
                var Services = db.ChildMasterTbls.Where(u => u.IsActive == 1).Select(a => new {
                    a.ID,
                    a.UserID,
                    a.SerialNumber,
                    a.CCIMasterTbl.InstitudeName,
                    CCIDistrictName = a.DistrictMasterTbl.DistrictName,
                    a.ChildCode,
                    a.ChildName,
                    a.Sex,
                    a.DOB,
                    a.Age,
                    a.Education,
                    a.SocialGroup,
                    a.SpecialChild,
                    a.MothersName,
                    a.MothersCurrentStatus,
                    a.FathersName,
                    a.FathersCurrentStatus,
                    a.SistersCount,
                    a.BrothersCount,
                    a.SiblingCount,
                    a.CaretakerAddress,
                    AddressDistrict =  a.DistrictMasterTbl3.DistrictName,
                    a.ContactNumber,
                    a.ClosestAliveRelative,
                    a.RelativeAddress,
                    a.RelativeContactNumber,
                    a.DataCollectionDate,
                    a.ChildCareInstitutionEnrollDate,
                    a.ChildConsentToFostering,
                    a.BiologicalParentsConsentToFostering,
                    a.InCCIFor,
                    a.PotentialForFoster,
                    a.IsFostering,
                    PlacementDistrict = a.DistrictMasterTbl1.DistrictName,
                    MonitoringDistrict = a.DistrictMasterTbl2.DistrictName,
                    a.LastFollowUpDate,
                    a.CreateDate,
                    a.ModifiedDate
                }).ToList();
                DataTable dt = new DataTable();
                string json = JsonConvert.SerializeObject(Services);
                dt = JsonConvert.DeserializeObject<System.Data.DataTable>(json);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "ChildMaster");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "ChildMaster" + DateTime.Now.ToString("dd-MMM-yyyy") + ".xlsx";
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
            var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2);
            ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");
            ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName").ToList();
            return View(childMasterTbls.Where(c => c.IsActive == 1).ToList().OrderByDescending(c => c.ID));
        }
        [HttpPost]
        public ActionResult Index( DateTime? FromDate,DateTime? ToDate , long? ChildID , long? DistrictID)
        {
            if (FromDate != null && ToDate != null && ChildID != null)
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.ID==ChildID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                return View(childMasterTbls.OrderByDescending(c => c.ID));
            }
           else if (FromDate != null && ToDate != null && DistrictID != null)
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.AddressDistrict == DistrictID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                return View(childMasterTbls.OrderByDescending(c => c.ID));
            }
          
            else if (ChildID != null)
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.ID == ChildID && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                return View(childMasterTbls.OrderByDescending(c => c.ID));
            }
            else if (DistrictID != null)
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.AddressDistrict == DistrictID && g.IsActive == 1).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                return View(childMasterTbls.OrderByDescending(c => c.ID));
            }
            if (FromDate != null && ToDate != null)
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.LastFollowUpDate >= FromDate && g.LastFollowUpDate <= ToDate && g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode", ChildID);
                return View(childMasterTbls.OrderByDescending(c => c.ID));
            }
            else
            {
                var childMasterTbls = db.ChildMasterTbls.Include(c => c.CCIMasterTbl).Include(c => c.DistrictMasterTbl).Include(c => c.DistrictMasterTbl1).Include(c => c.DistrictMasterTbl2).Where(g => g.IsActive == 1).ToList();
                ViewBag.DistrictID = new SelectList(db.DistrictMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, sb.DistrictName }), "ID", "DistrictName", DistrictID).ToList();
                ViewBag.ChildID = new SelectList(db.ChildMasterTbls.Where(sb => sb.IsActive == 1).Select(sb => new { sb.ID, ChildCode = sb.ChildName + " (" + sb.ChildCode + ")" }), "ID", "ChildCode");

                return View(childMasterTbls.OrderByDescending(c => c.ID));

            }
        }      
    }
}