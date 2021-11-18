using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Foreigner
    {
        [Required(ErrorMessage = "Firstname is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }


        [Required(ErrorMessage = "Passport is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Passport No")]
        public int PassPortNo { get; set; }


        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public String City { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public String Country { get; set; }


        [Required(ErrorMessage = "Date In is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date IN")]
        public String DateIn { get; set; }


        [Required(ErrorMessage = "Date Out is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Out")]
        public String DateOut { get; set; }
    }
}
