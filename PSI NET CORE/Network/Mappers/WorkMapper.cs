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

        public List<Work> MapToDomainList(List<WorkDto> t)
        {
            var domains = new List<Work>();
            foreach (var dto in t)
                domains.Add(MapToDomain(dto));
            return domains;
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

        public List<WorkDto> MapToDtoList(List<Work> t)
        {
            var dtos = new List<WorkDto>();
            foreach (var domain in t)
                dtos.Add(MapToDto(domain));
            return dtos;
        }
    }
}
