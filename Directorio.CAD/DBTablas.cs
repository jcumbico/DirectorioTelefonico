using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Directorio.CAD
{
    public class DBTablas:DbContext
    {
        public DbSet<Directorio.ENT.Persona> Personas { get; set; }
        public DbSet<Directorio.ENT.Cargo> Cargos { get; set; }
    }
}
