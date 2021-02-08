using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemeinschaftsBalkonWebApp01.Models
{
    public class LoginModel
    {

        [Display(Name = "Username")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Usaname must be between 2 and 10 characters.")]
        public string UserName { get; set; }

        [Display(Name = "Passwort")]
        [Required]
        [DataType(DataType.Password)]
        //[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        /*
        [Display(Name = "Admin/User")]
        public Nullable<bool> U_Admin { get; set; }
        */
    }
}