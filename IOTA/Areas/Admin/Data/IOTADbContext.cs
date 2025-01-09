using IOTA.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace IOTA.Areas.Admin.Data
{
    public class IOTADbContext : DbContext
    {
        public IOTADbContext(DbContextOptions<IOTADbContext> options) : base(options)
        {
        }

        public DbSet<HomePage> HomePage { get; set; }
    }
}
