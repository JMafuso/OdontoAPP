using Microsoft.EntityFrameworkCore;
using OdontoAPP.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OdontoAPP.Data
{
    public class OdontoDbContext : DbContext
    {
        public OdontoDbContext(DbContextOptions<OdontoDbContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}
