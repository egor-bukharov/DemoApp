using System.Collections.Generic;
using System.Linq;
using DemoApp.Controllers;
using DemoApp.Models;

namespace Demo.DataService
{
    public class TicketsService : ITicketsService
    {
        private readonly ApplicationDbContext _context;

        public TicketsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> GetAll()
        {
            
            return _context.Tickets
                .OrderBy(ticket => ticket.Name)
                .ToList();
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public Ticket FindById(long id)
        {
            return _context.Tickets.SingleOrDefault(ticket => ticket.Id == id);
        }
    }
}