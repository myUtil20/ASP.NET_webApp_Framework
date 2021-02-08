using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    [MetadataType(typeof(MetadataPflanzen))]
    public partial class Pflanzen
    {
        /* HelferProperties
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

    public class MetadataPflanzen 
    {

        public int P_ID { get; set; }

        [Display(Name = "Pflanzenname")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Zuname must be between 2 and 50 characters.")]
        public string P_Name { get; set; }

        [Display(Name = "Gepflanzt am")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //mit dem DatumsTyp funktioniert auch das client-seitige validieren
        public Nullable<System.DateTime> P_Gepflanzt { get; set; }

        [Display(Name = "Gekauft bei")]
        public Nullable<int> P_Kauf { get; set; }

        [Display(Name = "Blumentopf")]
        public Nullable<int> P_Topf { get; set; }

        [Display(Name = "Balkon")]
        public Nullable<int> P_Standort { get; set; }

        [Display(Name = "Steckbrief")]
        public Nullable<int> P_Steckbrief { get; set; }

        [Display(Name = "Blüht von")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> P_Bluet_Von { get; set; }

        [Display(Name = "Blüht bis")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> P_Bluet_Bis { get; set; }

        [Display(Name = "Notiz")]
        public string P_Notiz { get; set; }

        [Display(Name = "Schädling")]
        public Nullable<int> P_Schaedling { get; set; }

        [Display(Name = "Pate")]
        public Nullable<int> P_U_Besitzer { get; set; }

    }
}