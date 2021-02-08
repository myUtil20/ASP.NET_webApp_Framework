using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    [MetadataType(typeof(MetadataUser))]
    public partial class User
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

    public class MetadataUser
    {
        public int U_ID { get; set; }

        [Display(Name = "Username")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Usaname must be between 2 and 10 characters.")]
        public string U_Name { get; set; }

        [Display(Name = "Passwort")]
        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string U_PW { get; set; }

        [Display(Name = "Admin/User")]
        public Nullable<bool> U_Admin { get; set; }
    }
}