using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class OfficerMapper : IMap<OfficerDto, Officer>
    {
        public Officer MapToDomain(OfficerDto t)
        {
            return new Officer {
                Id=t.Id.ToString(),
                FirstName=t.FirstName,
                LastName=t.LastName,
                NationalID=t.NationalID,
                PostId=t.PostId,
                WorkId=t.WorkId,
                DateEmployed=t.DateEmployed
            };
        }
        

        public OfficerDto MapToDto(Officer t)
        {
            if(t.Id==null)
                return new OfficerDto
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    NationalID = t.NationalID,
                    PostId = t.PostId,
                    WorkId = t.WorkId,
                    DateEmployed = t.DateEmployed
                };
            return new OfficerDto
            {
                Id =Guid.Parse(t.Id),
                FirstName = t.FirstName,
                LastName = t.LastName,
                NationalID = t.NationalID,
                PostId = t.PostId,
                WorkId = t.WorkId,
                DateEmployed = t.DateEmployed
            };
        }
        
    }
}
