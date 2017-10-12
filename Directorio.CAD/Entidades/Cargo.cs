using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Directorio.CAD
{
    public class Cargo
    {
        public List<Directorio.ENT.Cargo> ListaCargo { get; set; }
        public int PaginaCantidadRegistros  { get; set; }

        public Cargo(int PaginaCantidadRegistros)
        {
            this.PaginaCantidadRegistros = PaginaCantidadRegistros;
        }

        public bool Leer(int PaginaNumero)
        {
            try
            {
                using (DBTablas DB = new DBTablas())
                {
                    ListaCargo = (from tabla
                                  in DB.Cargos
                                  orderby tabla.Nombre
                                  select tabla)
                                  .Skip((PaginaNumero - 1) * PaginaCantidadRegistros)
                                  .Take(PaginaCantidadRegistros)
                                  .ToList();
                }
                return true;
            }
            catch (Exception)
            {
                ListaCargo = null;
                return false;
            }
        }
    }
}
