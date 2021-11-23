using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class WorkMapper : IMap<WorkDto, Work>
    {
        public Work MapToDomain(WorkDto t)
        {
            return new Work
            {
                Id = t.Id.ToString(),
                Name=t.Name
            };
        }
        

        public WorkDto MapToDto(Work t)
        {
            if (t.Id==null)
                return new WorkDto
                {
                    Name = t.Name
                };
            return new WorkDto
            {
                Id =Guid.Parse(t.Id),
                Name = t.Name
            };
        }
        
    }
}
