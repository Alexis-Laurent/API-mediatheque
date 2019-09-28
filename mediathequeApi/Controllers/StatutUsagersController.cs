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
    public class StatutUsagersController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/StatutUsagers
        public IQueryable<StatutUsager> GetStatutUsager()
        {
            return db.StatutUsager;
        }

        // GET: api/StatutUsagers/5
        [ResponseType(typeof(StatutUsager))]
        public async Task<IHttpActionResult> GetStatutUsager(int id)
        {
            StatutUsager statutUsager = await db.StatutUsager.FindAsync(id);
            if (statutUsager == null)
            {
                return NotFound();
            }

            return Ok(statutUsager);
        }

        // PUT: api/StatutUsagers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatutUsager(int id, StatutUsager statutUsager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statutUsager.IdStatutUsager)
            {
                return BadRequest();
            }

            db.Entry(statutUsager).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatutUsagerExists(id))
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

        // POST: api/StatutUsagers
        [ResponseType(typeof(StatutUsager))]
        public async Task<IHttpActionResult> PostStatutUsager(StatutUsager statutUsager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatutUsager.Add(statutUsager);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statutUsager.IdStatutUsager }, statutUsager);
        }

        // DELETE: api/StatutUsagers/5
        [ResponseType(typeof(StatutUsager))]
        public async Task<IHttpActionResult> DeleteStatutUsager(int id)
        {
            StatutUsager statutUsager = await db.StatutUsager.FindAsync(id);
            if (statutUsager == null)
            {
                return NotFound();
            }

            db.StatutUsager.Remove(statutUsager);
            await db.SaveChangesAsync();

            return Ok(statutUsager);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatutUsagerExists(int id)
        {
            return db.StatutUsager.Count(e => e.IdStatutUsager == id) > 0;
        }
    }
}