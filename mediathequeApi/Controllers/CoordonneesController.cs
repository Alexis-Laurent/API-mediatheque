using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using mediathequeApi.Models;

namespace mediathequeApi.Controllers
{
    public class CoordonneesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Coordonnees
        public IQueryable<Coordonnees> GetCoordonnees()
        {
            return db.Coordonnees;
        }

        // GET: api/Coordonnees/5
        [ResponseType(typeof(Coordonnees))]
        public async Task<IHttpActionResult> GetCoordonnees(int id)
        {
            Coordonnees coordonnees = await db.Coordonnees.FindAsync(id);
            if (coordonnees == null)
            {
                return NotFound();
            }

            return Ok(coordonnees);
        }

        // PUT: api/Coordonnees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoordonnees(int id, Coordonnees coordonnees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordonnees.IdCoordonnees)
            {
                return BadRequest();
            }

            db.Entry(coordonnees).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordonneesExists(id))
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

        // POST: api/Coordonnees
        [ResponseType(typeof(Coordonnees))]
        public async Task<IHttpActionResult> PostCoordonnees(Coordonnees coordonnees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coordonnees.Add(coordonnees);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = coordonnees.IdCoordonnees }, coordonnees);
        }

        // DELETE: api/Coordonnees/5
        [ResponseType(typeof(Coordonnees))]
        public async Task<IHttpActionResult> DeleteCoordonnees(int id)
        {
            Coordonnees coordonnees = await db.Coordonnees.FindAsync(id);
            if (coordonnees == null)
            {
                return NotFound();
            }

            db.Coordonnees.Remove(coordonnees);
            await db.SaveChangesAsync();

            return Ok(coordonnees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordonneesExists(int id)
        {
            return db.Coordonnees.Count(e => e.IdCoordonnees == id) > 0;
        }
    }
}