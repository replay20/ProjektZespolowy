using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPracownik.Models;

namespace WebApplication1.Models.Data
{
    public class PracownicyContext : DbContext
    {
        public PracownicyContext(DbContextOptions<PracownicyContext> options)
          : base(options)
        {
        }

        public DbSet<Pracownik> Pracownik { get; set; }
    }
}
