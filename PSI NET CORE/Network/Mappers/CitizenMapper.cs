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
    }
}
