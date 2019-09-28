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
    public class TypeDocumentsController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/TypeDocuments
        public IQueryable<TypeDocument> GetTypeDocument()
        {
            return db.TypeDocument;
        }

        // GET: api/TypeDocuments/5
        [ResponseType(typeof(TypeDocument))]
        public async Task<IHttpActionResult> GetTypeDocument(int id)
        {
            TypeDocument typeDocument = await db.TypeDocument.FindAsync(id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            return Ok(typeDocument);
        }

        // PUT: api/TypeDocuments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTypeDocument(int id, TypeDocument typeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeDocument.IdTypeDocument)
            {
                return BadRequest();
            }

            db.Entry(typeDocument).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDocumentExists(id))
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

        // POST: api/TypeDocuments
        [ResponseType(typeof(TypeDocument))]
        public async Task<IHttpActionResult> PostTypeDocument(TypeDocument typeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeDocument.Add(typeDocument);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = typeDocument.IdTypeDocument }, typeDocument);
        }

        // DELETE: api/TypeDocuments/5
        [ResponseType(typeof(TypeDocument))]
        public async Task<IHttpActionResult> DeleteTypeDocument(int id)
        {
            TypeDocument typeDocument = await db.TypeDocument.FindAsync(id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            db.TypeDocument.Remove(typeDocument);
            await db.SaveChangesAsync();

            return Ok(typeDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeDocumentExists(int id)
        {
            return db.TypeDocument.Count(e => e.IdTypeDocument == id) > 0;
        }
    }
}