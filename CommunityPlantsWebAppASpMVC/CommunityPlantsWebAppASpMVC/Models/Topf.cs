//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunityPlantsWebAppASpMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Topf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topf()
        {
            this.Pflanzens = new HashSet<Pflanzen>();
        }
    
        public string T_Bez { get; set; }
        public Nullable<decimal> T_Breite { get; set; }
        public Nullable<decimal> T_Tiefe { get; set; }
        public Nullable<decimal> T_Hoehe { get; set; }
        public Nullable<int> T_Standort { get; set; }
        public int T_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pflanzen> Pflanzens { get; set; }
        public virtual Standort Standort { get; set; }
    }
}
