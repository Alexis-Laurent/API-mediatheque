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
    public class PromoesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Promoes
        public IQueryable<Promo> GetPromo()
        {
            return db.Promo;
        }

        // GET: api/Promoes/5
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> GetPromo(int id)
        {
            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }

            return Ok(promo);
        }

        // PUT: api/Promoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPromo(int id, Promo promo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promo.IdPromo)
            {
                return BadRequest();
            }

            db.Entry(promo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoExists(id))
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

        // POST: api/Promoes
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> PostPromo(Promo promo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Promo.Add(promo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = promo.IdPromo }, promo);
        }

        // DELETE: api/Promoes/5
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> DeletePromo(int id)
        {
            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }

            db.Promo.Remove(promo);
            await db.SaveChangesAsync();

            return Ok(promo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoExists(int id)
        {
            return db.Promo.Count(e => e.IdPromo == id) > 0;
        }
    }
}