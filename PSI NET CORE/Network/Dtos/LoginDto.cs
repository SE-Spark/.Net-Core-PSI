using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class LoginDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Username No")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Password")]
        public String Password { get; set; }

    }
}
