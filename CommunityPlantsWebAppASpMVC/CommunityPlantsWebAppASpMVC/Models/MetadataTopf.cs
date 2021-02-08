using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{

    [MetadataType(typeof(MetadataTopf))]
    public partial class Topf
    {
        /*
      * hier kann man ohne weiteres weitere GET methoden einbauen(SET zurückhaltend)
     public string Name
     {
         get { return this.S_Name + " " + this.S_Vorname; }            
     }

     public decimal? DNote
     {
         get { return this.pruefungens.Average(p => (decimal?)p.P_Note); }
     }
      */   
    }

    public class MetadataTopf
    {
        [Display(Name = "Bezeichnung")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Bezeichnung must be between 2 and 33 characters.")]
        public string T_Bez { get; set; }

        [Display(Name = "Breite(cm)")]
        public Nullable<decimal> T_Breite { get; set; }

        [Display(Name = "Tiefe(cm)")]
        public Nullable<decimal> T_Tiefe { get; set; }

        [Display(Name = "Höhe(cm)")]
        public Nullable<decimal> T_Hoehe { get; set; }

        [Display(Name = "Standort")]
        public Nullable<int> T_Standort { get; set; }

        public int T_ID { get; set; }
    }
}