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
    public class PotentialParentReportsController : Controller
    {
        private FosterCareDBEntities db = new FosterCareDBEntities();
        [ActionName("ExportToExcel")]
        public void ExportToExcel()
        {
            try
            {
                var Services = db.PotentialParentMasters.Where(u => u.IsActive == 1).Select(a => new {
                    a.ID,
                    a.UserID,
                    a.SerialNumber,
                    a.ApplicantsName,
                    a.ApplicantsAddress,
                    a.ContactNumber,
                    a.ApplicantsDOB,
                    a.Age,
                    a.ApplicantsHighestEducation,
                    a.MartialStatus,
                    a.DoYouHaveChildren,
                    a.ChildrenCount,
                    a.IsLegalCase,
                    a.IsKnowFosterCare,
                    a.YouWillingToFosterAChild,
                    a.AnyQuestion,
                    a.CreateDate,
                    a.ModifiedDate,

                }).ToList();
                DataTable dt = new DataTable();
                string json = JsonConvert.SerializeObject(Services);
                dt = JsonConvert.DeserializeObject<System.Data.DataTable>(json);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "PotentialParentReport");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "PotentialParentReport" + DateTime.Now.ToString("dd-MMM-yyyy") + ".xlsx";
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
                var PotentialParent = db.PotentialParentMasters.Where(p => p.IsActive == 1).ToList().OrderByDescending(p => p.ID);
                return View(PotentialParent);
            }
        }
    }
}