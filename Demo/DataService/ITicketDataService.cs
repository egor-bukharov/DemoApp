using System.Collections.Generic;
using Demo.Models;

namespace Demo.DataService
{
    public interface ITicketDataService
    {
        IList<Ticket> GetAll();
        Ticket FindById(long id);

        void Add(Ticket ticket);
    }
}