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
    public class TypeAbonnementsController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/TypeAbonnements
        public IQueryable<TypeAbonnement> GetTypeAbonnement()
        {
            return db.TypeAbonnement;
        }

        // GET: api/TypeAbonnements/5
        [ResponseType(typeof(TypeAbonnement))]
        public async Task<IHttpActionResult> GetTypeAbonnement(int id)
        {
            TypeAbonnement typeAbonnement = await db.TypeAbonnement.FindAsync(id);
            if (typeAbonnement == null)
            {
                return NotFound();
            }

            return Ok(typeAbonnement);
        }

        // PUT: api/TypeAbonnements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTypeAbonnement(int id, TypeAbonnement typeAbonnement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeAbonnement.IdTypeAbonnement)
            {
                return BadRequest();
            }

            db.Entry(typeAbonnement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeAbonnementExists(id))
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

        // POST: api/TypeAbonnements
        [ResponseType(typeof(TypeAbonnement))]
        public async Task<IHttpActionResult> PostTypeAbonnement(TypeAbonnement typeAbonnement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeAbonnement.Add(typeAbonnement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = typeAbonnement.IdTypeAbonnement }, typeAbonnement);
        }

        // DELETE: api/TypeAbonnements/5
        [ResponseType(typeof(TypeAbonnement))]
        public async Task<IHttpActionResult> DeleteTypeAbonnement(int id)
        {
            TypeAbonnement typeAbonnement = await db.TypeAbonnement.FindAsync(id);
            if (typeAbonnement == null)
            {
                return NotFound();
            }

            db.TypeAbonnement.Remove(typeAbonnement);
            await db.SaveChangesAsync();

            return Ok(typeAbonnement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeAbonnementExists(int id)
        {
            return db.TypeAbonnement.Count(e => e.IdTypeAbonnement == id) > 0;
        }
    }
}