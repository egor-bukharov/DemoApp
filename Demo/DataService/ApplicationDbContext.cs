using DemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}