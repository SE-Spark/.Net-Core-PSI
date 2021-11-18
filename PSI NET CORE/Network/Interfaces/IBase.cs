using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Interfaces
{
    public interface IBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> get();
        TEntity get(Object id);
        int insert(TEntity T);
        int update(Guid Id,TEntity T);
        int delete(TEntity T);
        int delete(Object id);
    }
}
