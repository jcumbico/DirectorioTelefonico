//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Directorio.CAD;
//using Directorio.ENT;

//namespace Directorio.CIU.MVC.Controllers
//{
//    public class Persona2Controller : Controller
//    {
//        private DBTablas db = new DBTablas();

//        // GET: Persona2
//        public ActionResult Index()
//        {
//            return View(db.Personas.ToList());
//        }

//        // GET: Persona2/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Directorio.ENT.Persona persona = db.Personas.Find(id);
//            if (persona == null)
//            {
//                return HttpNotFound();
//            }
//            return View(persona);
//        }

//        // GET: Persona2/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Persona2/Create
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
//        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Nombre1,Nombre2,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,FechaFallecimiento,FechaIngreso,FechaSalida,EstaActivo")] Directorio.ENT.Persona persona)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Personas.Add(persona);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(persona);
//        }

//        // GET: Persona2/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Directorio.ENT.Persona persona = db.Personas.Find(id);
//            if (persona == null)
//            {
//                return HttpNotFound();
//            }
//            return View(persona);
//        }

//        // POST: Persona2/Edit/5
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
//        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Nombre1,Nombre2,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,FechaFallecimiento,FechaIngreso,FechaSalida,EstaActivo")] Directorio.ENT.Persona persona)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(persona).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(persona);
//        }

//        // GET: Persona2/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Directorio.ENT.Persona persona = db.Personas.Find(id);
//            if (persona == null)
//            {
//                return HttpNotFound();
//            }
//            return View(persona);
//        }

//        // POST: Persona2/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ENT.Persona persona = db.Personas.Find(id);
//            db.Personas.Remove(persona);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
