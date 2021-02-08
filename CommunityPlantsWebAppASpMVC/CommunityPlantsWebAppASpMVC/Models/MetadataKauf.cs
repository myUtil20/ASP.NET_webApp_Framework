using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    [MetadataType(typeof(MetadataKauf))]
    public partial class Kauf
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
    public class MetadataKauf
    {
        public int K_ID { get; set; }

        [Display(Name = "Gekauft am")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> K_Datum { get; set; }

        [Display(Name = "Shop")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Zuname must be between 2 and 50 characters.")]
        public string K_Shop { get; set; }
        /*
        [Display(Name = "Gekauft am")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> K_Datum { get; set; }
        */
        [Display(Name = "Preis")]
        public Nullable<decimal> K_Preis { get; set; }

        [Display(Name = "Pate/Käufer")]
        public Nullable<int> K_U_ID { get; set; }
    }
}