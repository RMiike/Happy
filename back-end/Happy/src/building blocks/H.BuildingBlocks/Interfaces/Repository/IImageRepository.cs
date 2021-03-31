using H.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Repository
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<IEnumerable<Image>> Adicionar(IEnumerable<Image> entity);

    }
}
