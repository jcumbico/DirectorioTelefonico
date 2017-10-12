using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Directorio.CAD
{
    public class Persona
    {
        public List<Directorio.ENT.Persona> ListaPersona { get; set; }
        public int PaginaCantidadRegistros { get; set; }

        public Persona(int PaginaCantidadRegistros)
        {
            this.PaginaCantidadRegistros = PaginaCantidadRegistros;
        }
        public bool Crear(Directorio.ENT.Persona RegistroPersona)
        {
            try
            {
                using (DBTablas BD = new DBTablas())
                {
                    BD.Personas.Add(RegistroPersona);
                    BD.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Editar(Directorio.ENT.Persona RegistroPersona)
        {
            try
            {
                using (DBTablas BD = new DBTablas())
                {
                    BD.Entry(RegistroPersona).State = System.Data.Entity.EntityState.Modified;
                    BD.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Leer(int PaginaNumero)
        {
            try
            {
                using (DBTablas BD = new DBTablas())
                {
                    ListaPersona = (from tabla
                                   in BD.Personas
                                   orderby tabla.Id descending
                                   select tabla)
                                   .Skip((PaginaNumero - 1) * PaginaCantidadRegistros)
                                   .Take(PaginaCantidadRegistros)
                                   .ToList();
                }
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ListaPersona = null;
                return false;
            }
        }
        public bool Leer(int PersonaId, out Directorio.ENT.Persona RegistroPersona)
        {
            try
            {
                using (DBTablas BD = new DBTablas())
                {
                    RegistroPersona = BD.Personas.Find(PersonaId);
                }
                return true;
            }
            catch (Exception)
            {
                RegistroPersona = null;
                return false;
            }    
        }
    }
}
