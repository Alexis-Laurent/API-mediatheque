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
    public class StatutExemplairesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/StatutExemplaires
        public IQueryable<StatutExemplaire> GetStatutExemplaire()
        {
            return db.StatutExemplaire;
        }

        // GET: api/StatutExemplaires/5
        [ResponseType(typeof(StatutExemplaire))]
        public async Task<IHttpActionResult> GetStatutExemplaire(int id)
        {
            StatutExemplaire statutExemplaire = await db.StatutExemplaire.FindAsync(id);
            if (statutExemplaire == null)
            {
                return NotFound();
            }

            return Ok(statutExemplaire);
        }

        // PUT: api/StatutExemplaires/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatutExemplaire(int id, StatutExemplaire statutExemplaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statutExemplaire.IdStatutExemplaire)
            {
                return BadRequest();
            }

            db.Entry(statutExemplaire).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatutExemplaireExists(id))
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

        // POST: api/StatutExemplaires
        [ResponseType(typeof(StatutExemplaire))]
        public async Task<IHttpActionResult> PostStatutExemplaire(StatutExemplaire statutExemplaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatutExemplaire.Add(statutExemplaire);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statutExemplaire.IdStatutExemplaire }, statutExemplaire);
        }

        // DELETE: api/StatutExemplaires/5
        [ResponseType(typeof(StatutExemplaire))]
        public async Task<IHttpActionResult> DeleteStatutExemplaire(int id)
        {
            StatutExemplaire statutExemplaire = await db.StatutExemplaire.FindAsync(id);
            if (statutExemplaire == null)
            {
                return NotFound();
            }

            db.StatutExemplaire.Remove(statutExemplaire);
            await db.SaveChangesAsync();

            return Ok(statutExemplaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatutExemplaireExists(int id)
        {
            return db.StatutExemplaire.Count(e => e.IdStatutExemplaire == id) > 0;
        }
    }
}