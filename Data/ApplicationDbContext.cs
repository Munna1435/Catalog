using Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
