using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class StationMapper : IMap<StationDto, Station>
    {
        public Station MapToDomain(StationDto t)
        {           
            return new Station
            {
                Id = t.Id.ToString(),
                StationNo=t.StationNo,
                Name=t.Name,
                Location=t.Location,
                SubLocation=t.SubLocation,
                Ward=t.Ward,
                County=t.County
            };
        }
        
        public StationDto MapToDto(Station t)
        {
            if (t.Id == null)
                return new StationDto
                {
                    StationNo = t.StationNo,
                    Name = t.Name,
                    Location = t.Location,
                    SubLocation = t.SubLocation,
                    Ward = t.Ward,
                    County = t.County
                };
            return new StationDto
            {
                Id =Guid.Parse(t.Id),
                StationNo = t.StationNo,
                Name = t.Name,
                Location = t.Location,
                SubLocation = t.SubLocation,
                Ward = t.Ward,
                County = t.County
            };
        }
        
    }
}
