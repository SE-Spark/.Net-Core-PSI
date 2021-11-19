using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSI_NET_CORE.Network.Dtos
{
    public class OfficerDto
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        
        public String LastName { get; set; }
        
        public int NationalID { get; set; }
        
        public int PostId { get; set; }
        public int WorkId { get; set; }
        
        public String DateEmployed { get; set; }
    }
}
