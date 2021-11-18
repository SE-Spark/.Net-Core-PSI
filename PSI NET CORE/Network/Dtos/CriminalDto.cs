using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class CriminalDto
    {
        public int NationalID { get; set; }
        
        public int PassPortNo { get; set; }
        
        public String Crime { get; set; }
        
        public String Description { get; set; }        

        public String CrimeDate { get; set; }

    }
}
