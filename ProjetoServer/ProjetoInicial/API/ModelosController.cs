using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjetoInicial.Models;
using ProjetoInicial.Models.Context;

namespace ProjetoInicial.WebAPI
{
    public class ModelosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Modelos
        public IQueryable<Modelos> GetModelos()
        {
            return db.Modelos;
        }

        // GET: api/Modelos/5
        [ResponseType(typeof(Modelos))]
        public IHttpActionResult GetModelos(int id)
        {
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return NotFound();
            }

            return Ok(modelos);
        }

        // PUT: api/Modelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelos(int id, Modelos modelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelos.ModelosID)
            {
                return BadRequest();
            }

            db.Entry(modelos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Modelos
        [ResponseType(typeof(Modelos))]
        public IHttpActionResult PostModelos(Modelos modelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelos.Add(modelos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelos.ModelosID }, modelos);
        }

        // DELETE: api/Modelos/5
        [ResponseType(typeof(Modelos))]
        public IHttpActionResult DeleteModelos(int id)
        {
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return NotFound();
            }

            db.Modelos.Remove(modelos);
            db.SaveChanges();

            return Ok(modelos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelosExists(int id)
        {
            return db.Modelos.Count(e => e.ModelosID == id) > 0;
        }
    }
}