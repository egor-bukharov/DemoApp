using System;
using System.Collections.Generic;
using DemoApp.Controllers;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        [Route("api/Tickets")]
        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketsService.GetAll();
        }

        [HttpGet]
        [Route("api/Tickets/New")]
        public Ticket NewTicket()
        {
            var ticketsCount = _ticketsService.GetAll().Count;

            var ticket = new Ticket { Name = "Name" + ticketsCount, Description = "Description" + ticketsCount };
            _ticketsService.Add(ticket);

            return ticket;
        }

        [HttpGet]
        [Route("api/Tickets/{id}")]
        public IActionResult GetTicket(long id)
        {
            Ticket ticket = _ticketsService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut]
        [Route("api/Tickets/{id}")]
        public IActionResult PutTicket(long id, Ticket ticket)
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

            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/Tickets")]
        public IActionResult PostTicket(Ticket ticket)
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

            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("api/Tickets/{id}")]
        public IActionResult DeleteTicket(Guid id)
        {
            //Ticket ticket = db.Tickets.Find(id);
            //if (ticket == null)
            //{
            //    return NotFound();
            //}

            //db.Tickets.Remove(ticket);
            //db.SaveChanges();

            //return Ok(ticket);

            throw new NotImplementedException();
        }
    }
}