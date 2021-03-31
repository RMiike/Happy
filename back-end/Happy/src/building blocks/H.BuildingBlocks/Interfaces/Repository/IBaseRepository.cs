using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task<T> Adicionar(T entity);
        Task<bool> Deletar(T entity);
    }
}
