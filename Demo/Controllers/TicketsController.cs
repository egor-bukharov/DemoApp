using System;
using System.Collections.Generic;
using Demo.DataService;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketDataService _ticketDataService;

        public TicketsController(ITicketDataService ticketDataService)
        {
            _ticketDataService = ticketDataService;
        }

        [HttpGet]
        [Route("api/Tickets")]
        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketDataService.GetAll();
        }

        [HttpGet]
        [Route("api/Tickets/New")]
        public Ticket NewTicket()
        {
            var ticketsCount = _ticketDataService.GetAll().Count;

            var ticket = new Ticket { Name = "Name" + ticketsCount, Description = "Description" + ticketsCount };
            _ticketDataService.Add(ticket);

            return ticket;
        }

        [HttpGet]
        [Route("api/Tickets/{id}")]
        public IActionResult GetTicket(long id)
        {
            var ticket = _ticketDataService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut]
        [Route("api/Tickets/{id}")]
        public IActionResult PutTicket(long id, [FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        public IActionResult PostTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ticketDataService.Add(ticket);
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("api/Tickets/{id}")]
        public IActionResult DeleteTicket(long id)
        {
            throw new NotImplementedException();
        }
    }
}