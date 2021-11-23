using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Mappers
{   
    public interface IMap<Dto, DomainModel>
    {
        Dto MapToDto(DomainModel m);
        DomainModel MapToDomain(Dto t);

    }
}
