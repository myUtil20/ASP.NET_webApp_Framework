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
    
    public partial class Schaedling
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schaedling()
        {
            this.Pflanzens = new HashSet<Pflanzen>();
        }
    
        public int S_ID { get; set; }
        public string S_Bez { get; set; }
        public Nullable<int> S_P_ID { get; set; }
        public string S_Gegenmittel { get; set; }
        public Nullable<System.DateTime> S_Dat_letzteAnwendung { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pflanzen> Pflanzens { get; set; }
    }
}
