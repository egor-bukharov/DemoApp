using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class TicketsService : ITicketsService
    {
        public IList<Ticket> GetAll()
        {
            using (var dbContext = CreateDbContext())
            {
                return dbContext.Tickets
                    .OrderBy(ticket => ticket.Name)
                    .ToList();
            }
        }

        public void Add(Ticket ticket)
        {
            using (var dbContext = CreateDbContext())
            {
                dbContext.Tickets.Add(ticket);
                dbContext.SaveChanges();
            }
        }

        public Ticket FindById(Guid guid)
        {
            using (var dbContext = CreateDbContext())
            {
                return dbContext.Tickets.SingleOrDefault(ticket => ticket.Id == guid);
            }
        }

        protected virtual ApplicationDbContext CreateDbContext()
        {
            return new ApplicationDbContext();
        }
    }
}