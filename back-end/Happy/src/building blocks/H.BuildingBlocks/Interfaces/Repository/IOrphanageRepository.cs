using H.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Repository
{
    public interface IOrphanageRepository : IBaseRepository<Orphanage>
    {
        Task<IEnumerable<Orphanage>> ObterPendentes();
        Task<Orphanage> Update(Orphanage entity);

    }
}
