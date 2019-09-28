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
    public class PaiementsController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Paiements
        public IQueryable<Paiement> GetPaiement()
        {
            return db.Paiement;
        }

        // GET: api/Paiements/5
        [ResponseType(typeof(Paiement))]
        public async Task<IHttpActionResult> GetPaiement(int id)
        {
            Paiement paiement = await db.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            return Ok(paiement);
        }

        // PUT: api/Paiements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaiement(int id, Paiement paiement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paiement.IdPaiement)
            {
                return BadRequest();
            }

            db.Entry(paiement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiementExists(id))
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

        // POST: api/Paiements
        [ResponseType(typeof(Paiement))]
        public async Task<IHttpActionResult> PostPaiement(Paiement paiement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paiement.Add(paiement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paiement.IdPaiement }, paiement);
        }

        // DELETE: api/Paiements/5
        [ResponseType(typeof(Paiement))]
        public async Task<IHttpActionResult> DeletePaiement(int id)
        {
            Paiement paiement = await db.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            db.Paiement.Remove(paiement);
            await db.SaveChangesAsync();

            return Ok(paiement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaiementExists(int id)
        {
            return db.Paiement.Count(e => e.IdPaiement == id) > 0;
        }
    }
}