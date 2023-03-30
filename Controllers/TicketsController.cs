using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aviasales_v3.Data;
using Aviasales_v3.Models;

namespace Aviasales_v3.Controllers
{
    public class TicketsController : Controller
    {
        private readonly Aviasales_v3Context _context;

        public TicketsController(Aviasales_v3Context context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ticket.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        [HttpPost]
        public async Task<IActionResult> Refund(int Ticket_Number)
        {
            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Ticket_Number == Ticket_Number);
            var id = ticket.Id;
            return Redirect("Delete/" + id);
        }


        // GET: Tickets/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}


        // GET: Tickets/Create/5
        public async Task<IActionResult> Create(int Id)
        {
            //flight_id = 5; ////////////////./////////////////
            var rnd = new Random();
            var ticket_num = rnd.Next(0, 1000);
            var ticket = await _context.Ticket.FindAsync(ticket_num);
            while (ticket != null)
            {
                ticket_num = rnd.Next(0, 1000);
                ticket = await _context.Ticket.FindAsync(ticket_num);
            }
            var ticket_v2 = new Ticket();
            ticket_v2.Flight_Id = Id;
            ticket_v2.Ticket_Number = ticket_num;
            _context.Add(ticket_v2);
            await _context.SaveChangesAsync();
            var ticket_id = ticket_v2.Id;
            return Redirect("/Tickets/Details/"+ticket_id); //Details/"+ticket_id);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ticket_Number,Flight_Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ticket_Number,Flight_Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
