using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public interface ITicketsService
    {
        IList<Ticket> GetAll();
        void Add(Ticket ticket);
        Ticket FindById(Guid guid);
    }
}