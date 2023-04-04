using ASPWEBAPP.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPWEBAPP.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EMP> Employees{ get; set; }
    }
}
