//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FosterCare
{
    using System;
    using System.Collections.Generic;
    
    public partial class PermissionMasterTbl
    {
        public long Id { get; set; }
        public Nullable<long> RoleID { get; set; }
        public Nullable<long> ModuleID { get; set; }
        public Nullable<long> IsActive { get; set; }
    
        public virtual ModuleMasterTbl ModuleMasterTbl { get; set; }
        public virtual RoleMasterTbl RoleMasterTbl { get; set; }
    }
}
