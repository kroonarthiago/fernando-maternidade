//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maternity.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mother
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mother()
        {
            this.Baby = new HashSet<Baby>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Baby> Baby { get; set; }
    }
}
