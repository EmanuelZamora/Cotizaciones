using Concesionaria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concesionaria.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Clientes.ToList());
            }

        }
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Clientes.Where(x => x.IdCliente == id).FirstOrDefault());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Clientes clientes)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Clientes.Add(clientes);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Clientes.Where(x => x.IdCliente == id).FirstOrDefault());
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes clientes)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(clientes).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Clientes.Where(x => x.IdCliente == id).FirstOrDefault());
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Clientes clientes = context.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();
                    context.Clientes.Remove(clientes);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
