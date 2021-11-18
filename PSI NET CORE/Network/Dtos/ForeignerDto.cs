using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class ForeignerDto
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        
        public String LastName { get; set; }

        
        public int PassPortNo { get; set; }

        
        public String City { get; set; }
        
        public String Country { get; set; }
        
        public String DateIn { get; set; }
        
        public String DateOut { get; set; }
    }
}
