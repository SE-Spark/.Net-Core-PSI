using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Work
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public String Name { get; set; }

    }
}
