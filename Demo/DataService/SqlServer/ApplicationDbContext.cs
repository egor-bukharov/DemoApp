using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Demo.DataService.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}