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
    public class UsagersController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Usagers
        public IQueryable<Usager> GetUsager()
        {
            return db.Usager;
        }

        // GET: api/Usagers/5
        [ResponseType(typeof(Usager))]
        public async Task<IHttpActionResult> GetUsager(int id)
        {
            Usager usager = await db.Usager.FindAsync(id);
            if (usager == null)
            {
                return NotFound();
            }

            return Ok(usager);
        }

        // PUT: api/Usagers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsager(int id, Usager usager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usager.IdUsager)
            {
                return BadRequest();
            }

            db.Entry(usager).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsagerExists(id))
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

        // POST: api/Usagers
        [ResponseType(typeof(Usager))]
        public async Task<IHttpActionResult> PostUsager(Usager usager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usager.Add(usager);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usager.IdUsager }, usager);
        }

        // DELETE: api/Usagers/5
        [ResponseType(typeof(Usager))]
        public async Task<IHttpActionResult> DeleteUsager(int id)
        {
            Usager usager = await db.Usager.FindAsync(id);
            if (usager == null)
            {
                return NotFound();
            }

            db.Usager.Remove(usager);
            await db.SaveChangesAsync();

            return Ok(usager);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsagerExists(int id)
        {
            return db.Usager.Count(e => e.IdUsager == id) > 0;
        }
    }
}