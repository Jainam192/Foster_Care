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
    
    public partial class DistrictMasterTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DistrictMasterTbl()
        {
            this.ChildIndividualTbls = new HashSet<ChildIndividualTbl>();
            this.ChildIndividualTbls1 = new HashSet<ChildIndividualTbl>();
            this.ChildInstitutionTbls = new HashSet<ChildInstitutionTbl>();
            this.ChildInstitutionTbls1 = new HashSet<ChildInstitutionTbl>();
            this.ChildMasterTbls = new HashSet<ChildMasterTbl>();
            this.ChildMasterTbls1 = new HashSet<ChildMasterTbl>();
            this.ChildMasterTbls2 = new HashSet<ChildMasterTbl>();
            this.ChildMasterTbls3 = new HashSet<ChildMasterTbl>();
            this.FosterParentTbls = new HashSet<FosterParentTbl>();
            this.ParentMasterTbls = new HashSet<ParentMasterTbl>();
            this.TehsilMasterTbls = new HashSet<TehsilMasterTbl>();
        }
    
        public long ID { get; set; }
        public Nullable<long> StateID { get; set; }
        public string DistrictName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<long> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildIndividualTbl> ChildIndividualTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildIndividualTbl> ChildIndividualTbls1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildInstitutionTbl> ChildInstitutionTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildInstitutionTbl> ChildInstitutionTbls1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildMasterTbl> ChildMasterTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildMasterTbl> ChildMasterTbls1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildMasterTbl> ChildMasterTbls2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildMasterTbl> ChildMasterTbls3 { get; set; }
        public virtual StateMasterTbl StateMasterTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FosterParentTbl> FosterParentTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParentMasterTbl> ParentMasterTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TehsilMasterTbl> TehsilMasterTbls { get; set; }
    }
}
