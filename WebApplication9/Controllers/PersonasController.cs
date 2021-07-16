using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            List<Persona> ltspersona = new List<Persona>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("ListaPersona")))
            {
                Persona pers = new Persona();
                pers.Cedula = "02883884";
                pers.Nombre = "Alex";
                for (int i = 0; i < 10; i++)
                {
                    ltspersona.Add(pers);
                }
            }
            else
            {
                ltspersona = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
                
            }
            HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(ltspersona));
            return View(ltspersona);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Persona persona)
        {
            try
            {
                List<Persona> ltspersona = new List<Persona>();
                ltspersona = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
                ltspersona.Add(persona);
                HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(ltspersona));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
