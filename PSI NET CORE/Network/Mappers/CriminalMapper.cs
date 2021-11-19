using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class CriminalMapper : IMap<CriminalDto, Criminal>
    {
        public Criminal MapToDomain(CriminalDto t)
        {
            return new Criminal
            {
                Id= t.Id.ToString(),
                NationalID=t.NationalID,
                PassPortNo=t.PassPortNo,
                Crime=t.Crime,
                Description=t.Description,
                CrimeDate=t.CrimeDate
            };
        }

        public List<Criminal> MapToDomainList(List<CriminalDto> t)
        {
            var domains =new List<Criminal>();
            foreach (var dto in t)
            {
                domains.Add(MapToDomain(dto));
            }
            return domains;
        }

        public CriminalDto MapToDto(Criminal t)
        {
            if(t.Id==null)
                return new CriminalDto
                {
                    NationalID = t.NationalID,
                    PassPortNo = t.PassPortNo,
                    Crime = t.Crime,
                    Description = t.Description,
                    CrimeDate = t.CrimeDate
                };

            return new CriminalDto
            {
                Id = Guid.Parse(t.Id),
                NationalID = t.NationalID,
                PassPortNo = t.PassPortNo,
                Crime = t.Crime,
                Description = t.Description,
                CrimeDate = t.CrimeDate
            };
        }

        public List<CriminalDto> MapToDtoList(List<Criminal> t)
        {
            var dtos = new List<CriminalDto>();
            foreach(var domain in t)
            {
                dtos.Add(MapToDto(domain));
            }
            return dtos;
        }
    }
}
