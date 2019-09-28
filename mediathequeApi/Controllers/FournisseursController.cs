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
    public class FournisseursController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Fournisseurs
        public IQueryable<Fournisseur> GetFournisseur()
        {
            return db.Fournisseur;
        }

        // GET: api/Fournisseurs/5
        [ResponseType(typeof(Fournisseur))]
        public async Task<IHttpActionResult> GetFournisseur(int id)
        {
            Fournisseur fournisseur = await db.Fournisseur.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            return Ok(fournisseur);
        }

        // PUT: api/Fournisseurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFournisseur(int id, Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fournisseur.IdFournisseur)
            {
                return BadRequest();
            }

            db.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(id))
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

        // POST: api/Fournisseurs
        [ResponseType(typeof(Fournisseur))]
        public async Task<IHttpActionResult> PostFournisseur(Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fournisseur.Add(fournisseur);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fournisseur.IdFournisseur }, fournisseur);
        }

        // DELETE: api/Fournisseurs/5
        [ResponseType(typeof(Fournisseur))]
        public async Task<IHttpActionResult> DeleteFournisseur(int id)
        {
            Fournisseur fournisseur = await db.Fournisseur.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            db.Fournisseur.Remove(fournisseur);
            await db.SaveChangesAsync();

            return Ok(fournisseur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FournisseurExists(int id)
        {
            return db.Fournisseur.Count(e => e.IdFournisseur == id) > 0;
        }
    }
}