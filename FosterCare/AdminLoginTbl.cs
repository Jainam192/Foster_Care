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
    
    public partial class AdminLoginTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminLoginTbl()
        {
            this.ChildMasterTbls = new HashSet<ChildMasterTbl>();
            this.EnquiryTbls = new HashSet<EnquiryTbl>();
            this.ParentMasterTbls = new HashSet<ParentMasterTbl>();
            this.PotentialParentMasters = new HashSet<PotentialParentMaster>();
        }
    
        public long Id { get; set; }
        public string UserName { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public Nullable<long> Role { get; set; }
        public Nullable<long> IsActive { get; set; }
    
        public virtual RoleMasterTbl RoleMasterTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildMasterTbl> ChildMasterTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryTbl> EnquiryTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParentMasterTbl> ParentMasterTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PotentialParentMaster> PotentialParentMasters { get; set; }
    }
}
