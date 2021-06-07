using H.Domain.Entities;
using H.Domain.Models;
using System;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Service
{
    public interface IOrphanageService : IBaseService<OrphanageModel, CustomizedResult>
    {
        Task<CustomizedResult> ObterPendentes();
        Task<CustomizedResult> AprovarCadastro(Guid id);
    }
}
