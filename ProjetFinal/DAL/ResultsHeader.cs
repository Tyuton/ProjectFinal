//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResultsHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResultsHeader()
        {
            this.ResultsDetails = new HashSet<ResultsDetail>();
        }
    
        public System.Guid Id { get; set; }
        public System.DateTime QueryExecutionDate { get; set; }
        public Nullable<System.Guid> Selector_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsDetail> ResultsDetails { get; set; }
        public virtual Selector Selector { get; set; }
    }
}