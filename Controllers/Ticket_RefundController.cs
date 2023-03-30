using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aviasales_v3.Data;
using Aviasales_v3.Models;
using System.Data.Entity;

namespace Aviasales_v3.Controllers
{
    public class Ticket_RefundController : Controller
    {
        private readonly Aviasales_v3Context _context;

        public Ticket_RefundController(Aviasales_v3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Ticket_Number)
        {
            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Ticket_Number == Ticket_Number);
            var id = ticket.Id;
            return Redirect("/Tickets/Delete/"+id);
        }
    }
}
