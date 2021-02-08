using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    [MetadataType(typeof(MetadataSchad))]
    public partial class Schaedling
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

    public class MetadataSchad
    {
        public int S_ID { get; set; }

        [Display(Name = "Schädlingsname")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Zuname must be between 2 and 50 characters.")]
        public string S_Bez { get; set; }

        /*
         * Vielleicht eine Count Spalte von Schadling
         * 
        [Display(Name = "Befällt(Pflanze)")]
        public Nullable<int> S_P_ID { get; set; }
        *ist nicht verbunden! DB Fehler ! :( */

        [Display(Name = "Gegenmittel")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Zuname must be between 2 and 50 characters.")]
        public string S_Gegenmittel { get; set; }

        [Display(Name = "letzte Anwendung am")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> S_Dat_letzteAnwendung { get; set; }


    }
}