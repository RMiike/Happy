using H.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace H.Data.Context
{
    public class HappyContext : DbContext
    {
        public HappyContext(DbContextOptions<HappyContext> opt) : base(opt) { }
        public DbSet<Orphanage> Orphanages { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            foreach (var property in model.Model.GetEntityTypes().SelectMany(
               e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            model.ApplyConfigurationsFromAssembly(typeof(HappyContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
