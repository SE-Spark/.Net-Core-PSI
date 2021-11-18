using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Citizen
    {
        public String Id { get; set; }
        [Required(ErrorMessage ="Firstname is required")]
        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "National ID")]
        public int NationalID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required")]
        public String Location { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Sub Location")]
        [Required(ErrorMessage = "Sub Location is required")]
        public String SubLocation { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Ward")]
        [Required(ErrorMessage = "Ward is required")]
        public String Ward { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "County")]
        [Required(ErrorMessage = "County is required")]
        public String County { get; set; }
    }
}
