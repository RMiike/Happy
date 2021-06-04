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
    public class OrphanageRepository : IOrphanageRepository
    {

        private readonly HappyContext _context;

        public OrphanageRepository(HappyContext context)
        {
            _context = context;
        }
        public async Task<Orphanage> Adicionar(Orphanage entity)
        {
            var response = await _context.AddAsync(entity);

            var isCommited = await _context.Commit();
            return isCommited ? response.Entity : throw new InvalidOperationException();
        }

        public async Task<bool> Deletar(Orphanage entity)
        {
            _context.Orphanages.Remove(entity);
            return await _context.Commit();
        }

        public async Task<Orphanage> ObterPorId(Guid id)
        {
            var orphanage = await _context
                .Orphanages
                .Where(x => x.Id == id)
                .Select(e => new Orphanage(e.Id,
                                           e.Name,
                                           e.Latitude,
                                           e.Longitude,
                                           e.About,
                                           e.Instructions,
                                           e.OpeningHours,
                                           e.OpenOnWeekends,
                                           e.Images.ToList()))
                .FirstOrDefaultAsync();
            return orphanage;
        }

        public async Task<IEnumerable<Orphanage>> ObterTodos()
        {
            var aleatorio = _context.Orphanages.Select(e => e.Images.ToList()).ToList();


            var orphanages = await _context
                .Orphanages
                .Select(e => new Orphanage(
                   e.Id, e.Name, e.Latitude, e.Longitude, e.About, e.Instructions, e.OpeningHours, e.OpenOnWeekends, e.Images.ToList()))
                .AsNoTracking()
                .ToListAsync();
            return orphanages;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
