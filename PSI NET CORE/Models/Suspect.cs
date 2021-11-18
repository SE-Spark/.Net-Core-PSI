using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Suspect
    {
        [Required(ErrorMessage = "National ID is required")]
        [DataType(DataType.Text)]
        [Display(Name = "National ID")]
        public int NationalID { get; set; }

        [Required(ErrorMessage = "Passport is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Passport No")]
        public int PassPortNo { get; set; }

        [Required(ErrorMessage = "Allegation is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Allegation")]
        public String Allegation { get; set; }

        [Required(ErrorMessage = "Discription is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Discription")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public String AllegationDate { get; set; }

    }
}
