using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterCare.Areas.Admin.Data
{
    public class Authentication
    {
        public static bool Permission(long? RoleID, string URl)
        {
            FosterCareDBEntities db = new FosterCareDBEntities();
            var permission = db.PermissionMasterTbls.Where(p => p.RoleID == RoleID && p.ModuleMasterTbl.URL == URl).Count();
            if (permission > 0)
            {
                return true;
            }
            return false;
        }
    }
}