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
    public class AbonnementPromoesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/AbonnementPromoes
        public IQueryable<AbonnementPromo> GetAbonnementPromo()
        {
            return db.AbonnementPromo;
        }

        // GET: api/AbonnementPromoes/5
        [ResponseType(typeof(AbonnementPromo))]
        public async Task<IHttpActionResult> GetAbonnementPromo(int id)
        {
            AbonnementPromo abonnementPromo = await db.AbonnementPromo.FindAsync(id);
            if (abonnementPromo == null)
            {
                return NotFound();
            }

            return Ok(abonnementPromo);
        }

        // PUT: api/AbonnementPromoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAbonnementPromo(int id, AbonnementPromo abonnementPromo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonnementPromo.IdAbonnementPromo)
            {
                return BadRequest();
            }

            db.Entry(abonnementPromo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementPromoExists(id))
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

        // POST: api/AbonnementPromoes
        [ResponseType(typeof(AbonnementPromo))]
        public async Task<IHttpActionResult> PostAbonnementPromo(AbonnementPromo abonnementPromo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AbonnementPromo.Add(abonnementPromo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = abonnementPromo.IdAbonnementPromo }, abonnementPromo);
        }

        // DELETE: api/AbonnementPromoes/5
        [ResponseType(typeof(AbonnementPromo))]
        public async Task<IHttpActionResult> DeleteAbonnementPromo(int id)
        {
            AbonnementPromo abonnementPromo = await db.AbonnementPromo.FindAsync(id);
            if (abonnementPromo == null)
            {
                return NotFound();
            }

            db.AbonnementPromo.Remove(abonnementPromo);
            await db.SaveChangesAsync();

            return Ok(abonnementPromo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbonnementPromoExists(int id)
        {
            return db.AbonnementPromo.Count(e => e.IdAbonnementPromo == id) > 0;
        }
    }
}