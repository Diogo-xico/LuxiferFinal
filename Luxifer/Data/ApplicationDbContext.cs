using Luxifer.Data.Map;
using Luxifer.Models;
using Microsoft.EntityFrameworkCore;

namespace Luxifer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {           
        }
        public DbSet<Luminaria> Luminarias { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Grupo> Grupo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LuminariaMap());
            modelBuilder.ApplyConfiguration(new GruposMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
