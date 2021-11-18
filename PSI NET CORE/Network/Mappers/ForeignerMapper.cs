﻿using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class ForeignerMapper : IMap<ForeignerDto, Foreigner>
    {
        public Foreigner MapToDomain(ForeignerDto t)
        {
            return new Foreigner{
                Id = t.Id.ToString(),
                FirstName = t.FirstName,
                LastName=t.LastName,
                PassPortNo=t.PassPortNo,
                City=t.City,
                Country=t.Country,
                DateIn=t.DateIn,
                DateOut=t.DateOut
            };
        }

        public ForeignerDto MapToDto(Foreigner t)
        {
            if (t.Id==null)
            {
                return new ForeignerDto
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    PassPortNo = t.PassPortNo,
                    City = t.City,
                    Country = t.Country,
                    DateIn = t.DateIn,
                    DateOut = t.DateOut
                };
            }

            return new ForeignerDto
            {
                Id= Guid.Parse(t.Id),
                FirstName = t.FirstName,
                LastName = t.LastName,
                PassPortNo = t.PassPortNo,
                City = t.City,
                Country = t.Country,
                DateIn = t.DateIn,
                DateOut = t.DateOut
            };
        }
        public List<Foreigner> MapToDomainList(List<ForeignerDto> Dtos)
        {
            var domains = new List<Foreigner>();
            foreach (var dto in Dtos)
            {
                domains.Add(MapToDomain(dto));
            }
            return domains;
        }
        public List<ForeignerDto> MapToDtoList(List<Foreigner> domains)
        {
            var dtos = new List<ForeignerDto>();
            foreach (var domain in domains)
            {
                dtos.Add(MapToDto(domain));
            }
            return dtos;
        }
    }
}
