using System;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Service
{
    public interface IBaseService<T, Y> where T : class where Y : class
    {
        Task<Y> ObterTodos();
        Task<Y> ObterPorId(Guid id);
        Task<Y> Adicionar(T model);
        Task<Y> Deletar(Guid id);
    }
}
