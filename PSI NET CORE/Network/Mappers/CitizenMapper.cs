using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class CitizenMapper:IMap<CitizenDto, Citizen>
    {

        public Citizen MapToDomain(CitizenDto ct)
        {
            return new Citizen
            {
                Id = ct.Id.ToString(),
                FirstName = ct.FirstName,
                LastName = ct.LastName,
                NationalID = ct.NationalID,
                Location = ct.Location,
                SubLocation = ct.SubLocation,
                Ward = ct.Ward,
                County = ct.County
            };
        }

        public CitizenDto MapToDto(Citizen ct)
        {
            if (ct.Id == null)
                return new CitizenDto
                {
                    FirstName = ct.FirstName,
                    LastName = ct.LastName,
                    NationalID = ct.NationalID,
                    Location = ct.Location,
                    SubLocation = ct.SubLocation,
                    Ward = ct.Ward,
                    County = ct.County
                };

            return new CitizenDto
            {
                Id = Guid.Parse(ct.Id),
                FirstName = ct.FirstName,
                LastName = ct.LastName,
                NationalID = ct.NationalID,
                Location = ct.Location,
                SubLocation = ct.SubLocation,
                Ward = ct.Ward,
                County = ct.County
            };
        }
        public List<Citizen> MapToDomainList(List<CitizenDto> Dtos)
        {
            var citizens = new List<Citizen>();
            foreach (var dto in Dtos)
            {
               citizens.Add( MapToDomain(dto));
            }
            return citizens;
        }
        public List<CitizenDto> MapToDtoList(List<Citizen> domains)
        {
            var dtos = new List<CitizenDto>();
            foreach(var domain in domains)
            {
                dtos.Add(MapToDto(domain));
            }
            return dtos;
        }
    }
}
