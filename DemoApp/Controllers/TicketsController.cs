using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class TicketsController : ApiController
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        // GET: api/Tickets
        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketsService.GetAll();
        }

        // GET: api/Tickets/5
        [ResponseType(typeof(Ticket))]
        public IHttpActionResult GetTicket(Guid id)
        {
            Ticket ticket = _ticketsService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        //public Ticket GetTicket(int id)
        //{
        //    var ticket = new Ticket {Id = Guid.NewGuid(), Name = "Name", Description = "Description"};
        //    _ticketsService.Add(ticket);

        //    return ticket;
        //}

        // PUT: api/Tickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicket(Guid id, Ticket ticket)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != ticket.Id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(ticket).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TicketExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);

            return this.InternalServerError(new NotImplementedException());
        }

        // POST: api/Tickets
        [ResponseType(typeof(Ticket))]
        public IHttpActionResult PostTicket(Ticket ticket)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Tickets.Add(ticket);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (TicketExists(ticket.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = ticket.Id }, ticket);

            return this.InternalServerError(new NotImplementedException());
        }

        // DELETE: api/Tickets/5
        [ResponseType(typeof(Ticket))]
        public IHttpActionResult DeleteTicket(Guid id)
        {
            //Ticket ticket = db.Tickets.Find(id);
            //if (ticket == null)
            //{
            //    return NotFound();
            //}

            //db.Tickets.Remove(ticket);
            //db.SaveChanges();

            //return Ok(ticket);

            return this.InternalServerError(new NotImplementedException());
        }
    }
}