using H.BuildingBlocks.Interfaces.Repository;
using H.Data.Context;
using H.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly HappyContext _context;

        public ImageRepository(HappyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Image>> Adicionar(IEnumerable<Image> entity)
        {
            await _context.Images.AddRangeAsync(entity);
            var isCommited = await _context.Commit();
            return isCommited ? entity : throw new InvalidOperationException();
        }
        public async Task<Image> Adicionar(Image entity)
        {
            var response = await _context.AddAsync(entity);
            var isCommited = await _context.Commit();
            return isCommited ? response.Entity : throw new InvalidOperationException();
        }
        public async Task<bool> Deletar(Image entity)
        {
            _context.Images.Remove(entity);
            return await _context.Commit();
        }

        public async Task<Image> ObterPorId(Guid id)
        {
            var image = await _context.Images.Where(x => x.Id == id).FirstOrDefaultAsync();
            return image;
        }
        public async Task<IEnumerable<Image>> ObterPorIdDeOrfanato(Guid id)
        {
            var images = await _context.Images.Where(x => x.OrphanageId == id).ToListAsync();
            return images;
        }

        public async Task<IEnumerable<Image>> ObterTodos()
        {
            var images = await _context.Images.AsNoTracking().ToListAsync();
            return images;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


    }
}
