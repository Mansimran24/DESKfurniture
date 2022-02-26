using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DESKfurniture.Models;

namespace DESKfurniture.Data
{
    public class DESKfurnitureContext : DbContext
    {
        public DESKfurnitureContext (DbContextOptions<DESKfurnitureContext> options)
            : base(options)
        {
        }

        public DbSet<DESKfurniture.Models.Desk> Desk { get; set; }
    }
}
