using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataService.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}