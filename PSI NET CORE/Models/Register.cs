using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Models
{
    public class Register
    {

        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Username No")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password did not match")]
        public string confirmPswd { get; set; }
    }
}
