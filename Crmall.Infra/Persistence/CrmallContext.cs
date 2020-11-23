
using CrmallTeste.Domain.Entities;
using CrmallTeste.Infra.Persistence.Map;
using Microsoft.EntityFrameworkCore;

namespace CrmallTeste.Infra.Persistence
{
    public class CrmallContext : DbContext
    {
        public CrmallContext(DbContextOptions<CrmallContext> options) : base(options)
        {
        }

        public DbSet<Personal> Personal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonalMap());


        }
    }
}
