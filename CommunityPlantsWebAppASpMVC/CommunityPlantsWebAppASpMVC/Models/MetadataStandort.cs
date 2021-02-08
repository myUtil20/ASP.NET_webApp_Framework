using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    [MetadataType(typeof(MetadataStandort))]
    public partial class Standort
    {
        /*HelferProperties
         * hier kann man ohne weiteres weitere GET methoden einbauen(SET zurückhaltend)
          */


        public int? PflanzenMenge
        {
            get { return this.Pflanzens.Count; }
        }
        
    }
    public class MetadataStandort
    {
        public int SO_ID { get; set; }

        [Display(Name = "Standort")]
        public string SO_Bez { get; set; }
        
        [Display(Name = "Anzahl der Pflanzen")]
        public int PflanzenMenge{ get; set; }
        
    }
}