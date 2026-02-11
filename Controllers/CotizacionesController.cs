using Concesionaria.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Concesionaria.Controllers
{
    public class CotizacionesController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Cotizaciones
        public ActionResult Index()
        {
            var cotizaciones = db.Cotizaciones
                                 .Include("Clientes")
                                 .Include("Vehiculo")
                                 .Include("Bancos")
                                 .Include("Aseguradoras")
                                 .ToList();
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int id)
        {
            var cotizacion = db.Cotizaciones.Find(id);
            if (cotizacion == null) return HttpNotFound();
            return View(cotizacion);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            // Dropdowns para seleccionar IDs
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre");
            ViewBag.IdVehiculo = new SelectList(db.Vehiculo, "Id_Vehiculo", "Modelo");
            ViewBag.IdBanco = new SelectList(db.Bancos, "IdBanco", "Nombre");
            ViewBag.IdAseguradora = new SelectList(db.Aseguradoras, "IdAseguradora", "Nombre");

            return View();
        }

// POST: Cotizaciones/Create
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(Cotizaciones cotizacion)
{
    if (ModelState.IsValid)
    {
        cotizacion.Fecha = DateTime.Now; // opcional: asignar fecha automática
        db.Cotizaciones.Add(cotizacion);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Si hay error, recargar dropdowns
    ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", cotizacion.IdCliente);
    ViewBag.IdVehiculo = new SelectList(db.Vehiculo, "Id_Vehiculo", "Modelo", cotizacion.IdVehiculo);
    ViewBag.IdBanco = new SelectList(db.Bancos, "IdBanco", "Nombre", cotizacion.IdBanco);
    ViewBag.IdAseguradora = new SelectList(db.Aseguradoras, "IdAseguradora", "Nombre", cotizacion.IdAseguradora);

    return View(cotizacion);
}



        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int id)
        {
            var cotizacion = db.Cotizaciones.Find(id);
            if (cotizacion == null) return HttpNotFound();

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", cotizacion.IdCliente);
            ViewBag.IdVehiculo = new SelectList(db.Vehiculo, "Id_Vehiculo", "Modelo", cotizacion.IdVehiculo);
            ViewBag.IdBanco = new SelectList(db.Bancos, "IdBanco", "Nombre", cotizacion.IdBanco);
            ViewBag.IdAseguradora = new SelectList(db.Aseguradoras, "IdAseguradora", "Nombre", cotizacion.IdAseguradora);

            return View(cotizacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cotizaciones cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cotizacion);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int id)
        {
            var cotizacion = db.Cotizaciones.Find(id);
            if (cotizacion == null) return HttpNotFound();
            return View(cotizacion);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cotizacion = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}