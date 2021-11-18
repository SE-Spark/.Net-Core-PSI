using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Models
{
    public class Station
    {
        [DataType(DataType.Text)]
        [Display(Name = "Station Code")]
        [Required(ErrorMessage = "Station Code is required")]
        public int StationNo { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Station Name is required")]
        public String Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Locationis required")]
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
        [Display(Name = "Country")]
        [Required(ErrorMessage = "County is required")]
        public String County { get; set; }

    }
}
