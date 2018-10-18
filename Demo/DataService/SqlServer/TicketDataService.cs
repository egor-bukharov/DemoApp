using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.DataService.SqlServer
{
    public class TicketDataService : ITicketDataService
    {
        private readonly ApplicationDbContext _context;

        public TicketDataService(ApplicationDbContext context)
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