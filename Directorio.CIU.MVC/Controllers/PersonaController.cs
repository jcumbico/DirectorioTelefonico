 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Directorio.CAD;
//using System.Data.Entity;

namespace Directorio.CIU.MVC.Controllers
{
    public class PersonaController : Controller
    {
        private Directorio.CAD.Persona ClasePersona = new Directorio.CAD.Persona(10);
        private Directorio.CAD.Cargo ClaseCargo = new Directorio.CAD.Cargo(10);
        //private Directorio.CAD.DBTablas Conexion = new Directorio.CAD.DBTablas();

        [HttpGet]
        public ActionResult Index()
        {
            if (!ClasePersona.Leer(1))
            {
                return HttpNotFound();
            }

            return View(ClasePersona.ListaPersona);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            //Cargar datos adicionales para la vista.
            CargarCargos();

            // Colocar datos por omisión.
            Directorio.ENT.Persona RegistroPersona = new Directorio.ENT.Persona
            {
                Nombre1 = "digite nombre",
                ApellidoPaterno = "digite apellido",
                FechaNacimiento = new DateTime(1972, 8, 28),
                FechaIngreso = new DateTime(2017, 10, 7)
            };

            return View(RegistroPersona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Crear")]
        public ActionResult CrearPost(Directorio.ENT.Persona RegistroPersona)
        {

            //Validar los datos.
            if (ModelState.IsValid==false)
            {
                // Enviar el error al usuario.
                ModelState.AddModelError("","Hay errores, corregir.");
                CargarCargos(RegistroPersona.CargoAsignadoId);
                return View();
            }

            ClasePersona.Crear(RegistroPersona);
            //Grabar a la base de datos.
            //Conexion.Personas.Add(RegistroPersona);
            //Conexion.SaveChanges();

            //Mostrar al usuario mensaje de exito y mostrar el formulario de registro de persona en blanco.
            return RedirectToAction("Crear");
        }
        
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            Directorio.ENT.Persona RegistroPersona;
            //using (Directorio.CAD.DBTablas Conexion = new Directorio.CAD.DBTablas())
            //{
            //    RegistroPersona = Conexion.Personas.Find(Id);
            //}
            ClasePersona.Leer(Id, out RegistroPersona);
            CargarCargos(RegistroPersona.CargoAsignadoId);
            return View(RegistroPersona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Directorio.ENT.Persona RegistroPersona)
        {
            //Validar datos.
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "hay errores, corregir.");
                CargarCargos(RegistroPersona.CargoAsignadoId);
                return View();
            }

            //Grabar a la base de datos
            ClasePersona.Editar(RegistroPersona);
            //Conexion.Entry(RegistroPersona).State = EntityState.Modified;
            //Conexion.SaveChanges();

            //Mostrar la lista de personas.
            return RedirectToAction("Index");
        }

        private void CargarCargos(int IdSeleccion = 0)
        {
            if (!ClaseCargo.Leer(1))
            {
                ViewBag.ListaCargo = null;
            }

            List<SelectListItem> ComboBox = new List<SelectListItem>();
            foreach (var item in ClaseCargo.ListaCargo)
                ComboBox.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Nombre,
                    Selected = item.Id == IdSeleccion
                });
                
            ViewBag.ListaCargo = ComboBox;
        }
    }
}