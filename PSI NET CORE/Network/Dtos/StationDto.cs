using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class StationDto
    {
        public int StationNo { get; set; }
        
        public String Name { get; set; }
        public String Location { get; set; }
        
        public String SubLocation { get; set; }
        
        public String Ward { get; set; }
        
        public String County { get; set; }

    }
}
