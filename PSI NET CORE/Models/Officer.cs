using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Officer
    {

        [Required(ErrorMessage = "First Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [DataType(DataType.Text)]
        [Display(Name = "National ID")]
        public int NationalID { get; set; }

        [Required(ErrorMessage = "Post Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Post Name ID")]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Work Type is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Designation/Work")]
        public int WorkId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "National ID")]
        public String DateEmployed { get; set; }
        //public String DateEmployed { get { return DateTime.Now.ToShortDateString(); } set => value }
    }
}
