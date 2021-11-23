using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class CitizenDto
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        
        public String LastName { get; set; }
        
        public int NationalID { get; set; }
        
        public String Location { get; set; }
        
        public String SubLocation { get; set; }
        
        public String Ward { get; set; }
        
        public String County { get; set; }

        public List<CriminalDto> Criminals { get; set; }
    }
}
