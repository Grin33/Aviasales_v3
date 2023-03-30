using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aviasales_v3.Models;

namespace Aviasales_v3.Data
{
    public class Aviasales_v3Context : DbContext
    {
        public Aviasales_v3Context (DbContextOptions<Aviasales_v3Context> options)
            : base(options)
        {
        }

        public DbSet<Aviasales_v3.Models.Flight> Flight { get; set; }

        public DbSet<Aviasales_v3.Models.Ticket> Ticket { get; set; }
    }
}
