using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dos_modulos.Model;

namespace dos_modulos.Data
{
    public class dos_modulosContext : DbContext
    {
        public dos_modulosContext (DbContextOptions<dos_modulosContext> options)
            : base(options)
        {
        }

        public DbSet<dos_modulos.Model.Notas> Notas { get; set; } = default!;
        public DbSet<dos_modulos.Model.Examen> Examen { get; set; } = default!;
    }
}
