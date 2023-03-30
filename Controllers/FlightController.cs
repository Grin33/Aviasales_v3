using Aviasales_v3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aviasales_v3.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Aviasales_v3.Controllers
{
    public class FlightController : Controller
    {
        private readonly Aviasales_v3Context _context;

        public FlightController(Aviasales_v3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Check(Flight flight)
        {
            var flights = from m in _context.Flight
                          select m;

            if (ModelState.IsValid)
            {
                flights = flights.Where
                (s =>
                    s.Where_From.Contains(flight.Where_From)
                    && s.Where_To.Contains(flight.Where_To)
                //&& s.When.ToString().Contains(flight.When.ToString())
                //Добавить по дате
                );
            }

            return View(await flights.ToListAsync());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Booking(int? flight_id)
        //{
        //    flight_id = 5;
        //    if (flight_id == null)
        //    {
        //        return NotFound();
        //    }
        //    var flight = await _context.Flight.FindAsync(flight_id);
        //    if (flight == null)
        //    {
        //        return NotFound();
        //    }
        //    flight.Free_Seats--;

        //    var rnd = new Random();
        //    var ticket_num = rnd.Next(0, 1000);
        //    var ticket = await _context.Ticket.FindAsync(ticket_num);
        //    while (ticket != null) 
        //    {
        //        ticket_num = rnd.Next(0, 1000);
        //        ticket = await _context.Ticket.FindAsync(ticket_num);
        //    }
        //    _context.Add(ticket);
        //    await _context.SaveChangesAsync();
        //    var conid = ticket.Id;

        //    return Redirect("Ticket/Details/" +conid); //перекинуться на создание тикета с id рейса и рандомным номером билета
        //}

        //[HttpPost]
        //public async Task<ActionResult> Booking(int id)
        //{
        //    //id = 5;
        //    var flight = await _context.Flight
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    try
        //    {
        //        flight.Free_Seats--;
        //        _context.Update(flight);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FlightExists(flight.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return View("Booking");
        //}


        //public async Task<IActionResult> Create(int flight_id)
        //{
        //    //flight_id = 5; ////////////////./////////////////
        //    var rnd = new Random();
        //    var ticket_num = rnd.Next(0, 1000);
        //    var ticket = await _context.Ticket.FindAsync(ticket_num);
        //    while (ticket != null)
        //    {
        //        ticket_num = rnd.Next(0, 1000);
        //        ticket = await _context.Ticket.FindAsync(ticket_num);
        //    }
        //    var ticket_v2 = new Ticket();
        //    ticket_v2.Flight_Id = flight_id;
        //    ticket_v2.Ticket_Number = ticket_num;
        //    _context.Add(ticket_v2);
        //    await _context.SaveChangesAsync();
        //    var ticket_id = ticket_v2.Id;
        //    return Redirect("Index/Tickets/Details/" + ticket_id); //Details/"+ticket_id);
        //}

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
