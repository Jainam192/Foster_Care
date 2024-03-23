using FosterCare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FosterCare.Controllers
{
    public class HomeApiController : ApiController
    {
        FosterCareDBEntities db = new FosterCareDBEntities();

        [HttpGet]
        [ActionName("SendOTP")]
        public IHttpActionResult SendOTP(string mobileno)
        {
            try
            {
                var dbUserID = db.AdminLoginTbls.Where(c => c.ContactNumber == mobileno && c.IsActive == 1).FirstOrDefault();
                if (dbUserID != null)
                {
                    string chars = "0123456789";
                    Random rdm = new Random();
                    var otp = new string(Enumerable.Repeat(chars, 6).Select(s => s[rdm.Next(s.Length)]).ToArray());
                    Comman.sendsms("Your Login Authentication One Time Password (OTP) is: " + otp + ", Do not share with others. Regards: COMBAT by UNICEF Rajasthan. ", mobileno, "1207165535740129341");
                    var data = new
                    {
                        userotp = otp,
                        UserID = dbUserID.Id,
                        Message = "OTP Sent Successfully"
                    };
                    return Ok(data);
                }
                else
                {
                    return Ok(new { Message = "Mobile Number Not Registered with Us" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("AppLogin")]
        public IHttpActionResult AppLogin(long UserID)
        {
            try
            {
                var UserDetails = db.AdminLoginTbls.Where(c => c.Id == UserID && c.IsActive == 1).Select(c => new { c.Id, c.UserName }).FirstOrDefault();
                if (UserDetails != null)
                {
                    var data = new
                    {
                        UserID = UserDetails.Id,
                        UserName = UserDetails.UserName,
                        Message = "You have successfully Logged In"
                    };
                    return Ok(data);
                }
                else
                {
                    var data = new
                    {
                        UserID = "0",
                        Message = "User Not Found"
                    };
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ActionName("getChildform")]
        public IHttpActionResult getChildform()
        {
            try
            {
                var CCIMasters = db.CCIMasterTbls.Where(c => c.IsActive == 1).Select(s => new { s.ID, s.InstitudeName }).ToList();
                var Districts = db.DistrictMasterTbls.Where(c => c.IsActive == 1).Select(s => new { s.ID, s.DistrictName }).ToList();
                
                return Ok(new { CCIMasters, Districts });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("getParentForm")]
        public IHttpActionResult getParentForm()
        {
            try
            {
               
                var Districts = db.DistrictMasterTbls.Where(c => c.IsActive == 1).Select(s => new { s.ID, s.DistrictName }).ToList();
                
                return Ok(new { Districts });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("PostChildData")]
        public IHttpActionResult PostChildData(ChildMasterTbl childMasterTbl)
        {
            try
            {
                childMasterTbl.Age = Math.Round((double)childMasterTbl.Age, 1);
                childMasterTbl.CreateDate = DateTime.Now;
                childMasterTbl.IsActive = 1;
                db.ChildMasterTbls.Add(childMasterTbl);
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [ActionName("getChildData")]
        public IHttpActionResult getChildData(long Userid)
        {
            try
            {
                var childMasterTbls = db.ChildMasterTbls.Where(c => c.IsActive == 1 && c.UserID == Userid).Select(c => new { c.ID, c.UserID, c.SerialNumber, c.CCIMasterTbl.InstitudeName, CCIDistrict = c.DistrictMasterTbl.DistrictName, c.ChildCode, c.ChildName, c.Sex, c.DOB, c.Age, c.Education, c.SocialGroup, c.SpecialChild, c.MothersName, c.MothersCurrentStatus, c.FathersName, c.FathersCurrentStatus, c.SistersCount, c.BrothersCount, c.SiblingCount, c.CaretakerAddress, AddressDistrict = c.DistrictMasterTbl1.DistrictName, c.ContactNumber, c.ClosestAliveRelative, c.RelativeAddress, c.RelativeContactNumber, c.DataCollectionDate, c.ChildCareInstitutionEnrollDate, c.ChildConsentToFostering, c.BiologicalParentsConsentToFostering, c.InCCIFor, c.PotentialForFoster, c.IsFostering, PlacementDistrict = c.DistrictMasterTbl2.DistrictName, MonitoringDistrict = c.DistrictMasterTbl3.DistrictName, c.LastFollowUpDate });

                return Ok(new { count = childMasterTbls.Count(), data = childMasterTbls.ToList() });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [ActionName("EditChildData")]
        public IHttpActionResult EditChildData(long id)
        {
            try
            {
                var childMasterTbls = db.ChildMasterTbls.Where(c => c.IsActive == 1 && c.ID == id).Select(c => new { c.ID, c.UserID, c.SerialNumber, c.CCIMasterID, CCIDistrict = c.DistrictID, c.ChildCode, c.ChildName, c.Sex, c.DOB, c.Age, c.Education, c.SocialGroup, c.SpecialChild, c.MothersName, c.MothersCurrentStatus, c.FathersName, c.FathersCurrentStatus, c.SistersCount, c.BrothersCount, c.SiblingCount, c.CaretakerAddress, AddressDistrict = c.AddressDistrict, c.ContactNumber, c.ClosestAliveRelative, c.RelativeAddress, c.RelativeContactNumber, c.DataCollectionDate, c.ChildCareInstitutionEnrollDate, c.ChildConsentToFostering, c.BiologicalParentsConsentToFostering, c.InCCIFor, c.PotentialForFoster, c.IsFostering,  PlacementDistrict = c.PlacementDistrict, MonitoringDistrict = c.MonitoringDistrict, c.LastFollowUpDate }).FirstOrDefault();

                return Ok(childMasterTbls);
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("UpdateChildData")]
        public IHttpActionResult UpdateChildData(ChildMasterTbl childMasterTbl)
        {
            try
            {
                childMasterTbl.Age = Math.Round((double)childMasterTbl.Age, 1);
                childMasterTbl.ModifiedDate = DateTime.Now;
                childMasterTbl.IsActive = 1;
                db.Entry(childMasterTbl).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("PostParentData")]
        public IHttpActionResult PostParentData(ParentMasterTbl parentMasterTbl)
        {
            try
            {
                parentMasterTbl.CreateDate = DateTime.Now;
                parentMasterTbl.IsActive = 1;
                db.ParentMasterTbls.Add(parentMasterTbl);
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("getParentData")]
        public IHttpActionResult getParentData(long Userid)
        {
            try
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(p => p.UserID == Userid && p.IsActive == 1).Select(p => new { p.ID, p.UserID, p.FosterParentSerialNumber, FosterParentDistrict = p.DistrictMasterTbl.DistrictName, p.ParentCode, p.FosterMothersName, p.FosterMothersDOB, p.FosterMotherCurrentStatus, p.FosterMotherHighestEducation, p.FosterMotherEmploymentStatus, p.FosterMotherIncome, p.FosterFathersName, p.FosterFathersDOB, p.FosterFathersCurrentStatus, p.FosterFathersHighestEducation, p.FosterFathersEmploymentStatus, p.FosterFathersIncome, p.Address, p.ContactNumber, p.FosterGirlsCount, p.FosterBoysCount, p.RationCardFosterChildrenCount, p.AnyOtherFosters, p.ChildSheetFosteredChildrenCount, p.AdoptedChildrenCount, p.BiologicalChildrenCount, p.PlacementDate, p.ReasonForFostering, p.LastExtensionDate, p.ExtensionPeriod, p.TerminationDate,p.ReasonForTermination, p.LastFollowUpDate  });
                return Ok(new { count = parentMasterTbls.Count() ,data = parentMasterTbls.ToList() });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("EditParentData")]
        public IHttpActionResult EditParentData(long id)
        {
            try
            {
                var parentMasterTbls = db.ParentMasterTbls.Where(c => c.IsActive == 1 && c.ID == id).Select(p => new { p.ID, p.UserID, p.FosterParentSerialNumber, p.FosterParentDistrict,p.ParentCode, p.FosterMothersName, p.FosterMothersDOB, p.FosterMotherCurrentStatus, p.FosterMotherHighestEducation, p.FosterMotherEmploymentStatus, p.FosterMotherIncome, p.FosterFathersName, p.FosterFathersDOB, p.FosterFathersCurrentStatus, p.FosterFathersHighestEducation, p.FosterFathersEmploymentStatus, p.FosterFathersIncome, p.Address, p.ContactNumber, p.FosterGirlsCount, p.FosterBoysCount, p.RationCardFosterChildrenCount, p.AnyOtherFosters, p.ChildSheetFosteredChildrenCount, p.AdoptedChildrenCount, p.BiologicalChildrenCount, p.PlacementDate, p.ReasonForFostering, p.LastExtensionDate, p.ExtensionPeriod, p.TerminationDate, p.ReasonForTermination,p.LastFollowUpDate }).FirstOrDefault();

                return Ok(parentMasterTbls);
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("UpdateParentData")]
        public IHttpActionResult UpdateParentData(ParentMasterTbl parentMasterTbl)
        {
            try
            {
                parentMasterTbl.ModifiedDate = DateTime.Now;
                parentMasterTbl.IsActive = 1;
                db.Entry(parentMasterTbl).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [ActionName("PostPotentialParentData")]
        public IHttpActionResult PostPotentialParentData(PotentialParentMaster potentialParentMaster)
        {
            try
            {
                potentialParentMaster.Age = Math.Round((double)potentialParentMaster.Age, 1);
                potentialParentMaster.CreateDate = DateTime.Now;
                potentialParentMaster.IsActive = 1;
                db.PotentialParentMasters.Add(potentialParentMaster);
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [ActionName("getPotentialParentData")]
        public IHttpActionResult getPotentialParentData(long Userid)
        {
            try
            {
                var potentialParentMaster = db.PotentialParentMasters.Where(p => p.IsActive == 1 && p.UserID == Userid).Select(p => (new { p.ID,p.UserID,p.SerialNumber,p.ApplicantsName,p.ApplicantsAddress,p.ContactNumber,p.ApplicantsDOB, p.Age,p.ApplicantsHighestEducation,p.MartialStatus,p.DoYouHaveChildren,p.ChildrenCount,p.IsLegalCase,p.IsKnowFosterCare,p.YouWillingToFosterAChild,p.AnyQuestion }));
                return Ok(new { count = potentialParentMaster.Count(), data = potentialParentMaster.ToList() });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("EditPotentialParentData")]
        public IHttpActionResult EditPotentialParentData(long id)
        {
            try
            {
                var potentialParentMasterTbl = db.PotentialParentMasters.Where(c => c.IsActive == 1 && c.ID == id).Select(p => (new { p.ID, p.UserID, p.SerialNumber, p.ApplicantsName, p.ApplicantsAddress, p.ContactNumber, p.ApplicantsDOB, p.Age, p.ApplicantsHighestEducation, p.MartialStatus, p.DoYouHaveChildren, p.ChildrenCount, p.IsLegalCase, p.IsKnowFosterCare, p.YouWillingToFosterAChild, p.AnyQuestion })).FirstOrDefault();

                return Ok(potentialParentMasterTbl);
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("UpdatePotentialParentData")]
        public IHttpActionResult UpdatePotentialParentData(PotentialParentMaster potentialParentMaster)
        {
            try
            {
                potentialParentMaster.Age = Math.Round((double)potentialParentMaster.Age, 1);
                potentialParentMaster.ModifiedDate = DateTime.Now;
                potentialParentMaster.IsActive = 1;
                db.Entry(potentialParentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("getDashBoard")]
        public IHttpActionResult getDashBoard()
        {
            try
            {
                var ChildCount = db.ChildMasterTbls.Where(c => c.IsActive == 1).Count();
                var ParentCount = db.ParentMasterTbls.Where(c => c.IsActive == 1).Count();
                var PotentialParentCount = db.PotentialParentMasters.Where(s => s.IsActive == 1).Count();
                var EnquiryCount = db.EnquiryTbls.Where(e => e.IsActive == 1).Count();
                return Ok(new { ChildCount, ParentCount, PotentialParentCount, EnquiryCount });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpPost]
        [ActionName("PostEnquiryData")]
        public IHttpActionResult PostEnquiryData(EnquiryTbl enquiryTbl)
        {
            try
            {
                enquiryTbl.CreateDate = DateTime.Now;
                enquiryTbl.IsActive = 1;
                db.EnquiryTbls.Add(enquiryTbl);
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("getEnquiryData")]
        public IHttpActionResult getEnquiryData(long Userid)
        {
            try
            {
                var enquiryTbls = db.EnquiryTbls.Where(p => p.UserID == Userid && p.IsActive == 1).Select(p => new { p.ID, p.UserID, p.Name ,p.ContactNumber , p.Address , p.Message });
                return Ok(new { count = enquiryTbls.Count(), data = enquiryTbls.ToList() });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [ActionName("EditEnquiryData")]
        public IHttpActionResult EditEnquiryData(long id)
        {
            try
            {
                var enquiryTbls = db.EnquiryTbls.Where(c => c.IsActive == 1 && c.ID == id).Select(c => new { c.ID, c.UserID ,c.Name,c.ContactNumber,c.Address,c.Message}).FirstOrDefault();

                return Ok(enquiryTbls);
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
        [HttpPost]
        [ActionName("UpdateEnquiryData")]
        public IHttpActionResult UpdateEnquiryData(EnquiryTbl enquiryTbl)
        {
            try
            {
                enquiryTbl.ModifiedDate = DateTime.Now;
                enquiryTbl.IsActive = 1;
                db.Entry(enquiryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(new { Message = "Data Successfully Submitted" });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message });
            }
        }
    }
}
