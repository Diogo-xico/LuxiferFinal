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
    }
}
