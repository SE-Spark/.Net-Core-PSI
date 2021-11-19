﻿using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{
    public class SuspectMapper : IMap<SuspectDto, Suspect>
    {
        public Suspect MapToDomain(SuspectDto t)
        {
            return new Suspect
            {
                Id= t.Id.ToString(),
                NationalID= t.NationalID,
                PassPortNo=t.PassPortNo,
                Allegation=t.Allegation,
                Description=t.Description,
                AllegationDate=t.AllegationDate
            };
        }

        public List<Suspect> MapToDomainList(List<SuspectDto> t)
        {
            var domain = new List<Suspect>();
            foreach (var dto in t)
                domain.Add(MapToDomain(dto));
            return domain;
        }

        public SuspectDto MapToDto(Suspect t)
        {
            if(t.Id==null)
                return new SuspectDto
                {
                    NationalID = t.NationalID,
                    PassPortNo = t.PassPortNo,
                    Allegation = t.Allegation,
                    Description = t.Description,
                    AllegationDate = t.AllegationDate
                };

            return new SuspectDto
            {
                Id =Guid.Parse(t.Id),
                NationalID = t.NationalID,
                PassPortNo = t.PassPortNo,
                Allegation = t.Allegation,
                Description = t.Description,
                AllegationDate = t.AllegationDate
            };
        }

        public List<SuspectDto> MapToDtoList(List<Suspect> t)
        {
            var dtos = new List<SuspectDto>();
            foreach (var domain in t)
                dtos.Add(MapToDto(domain));
            return dtos;
        }
    }
}
