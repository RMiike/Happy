using H.Domain.Entities;
using H.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.BuildingBlocks.Interfaces.Service
{
    public interface IImageService
    {
        Task<string> ObterPorId(Guid id);
        Task<IEnumerable<Image>> Adicionar(ImageModel Model);
    }
}
