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
    public class ClassificationAgesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/ClassificationAges
        public IQueryable<ClassificationAge> GetClassificationAge()
        {
            return db.ClassificationAge;
        }

        // GET: api/ClassificationAges/5
        [ResponseType(typeof(ClassificationAge))]
        public async Task<IHttpActionResult> GetClassificationAge(int id)
        {
            ClassificationAge classificationAge = await db.ClassificationAge.FindAsync(id);
            if (classificationAge == null)
            {
                return NotFound();
            }

            return Ok(classificationAge);
        }

        // PUT: api/ClassificationAges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClassificationAge(int id, ClassificationAge classificationAge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classificationAge.IdClassificationAge)
            {
                return BadRequest();
            }

            db.Entry(classificationAge).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationAgeExists(id))
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

        // POST: api/ClassificationAges
        [ResponseType(typeof(ClassificationAge))]
        public async Task<IHttpActionResult> PostClassificationAge(ClassificationAge classificationAge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassificationAge.Add(classificationAge);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = classificationAge.IdClassificationAge }, classificationAge);
        }

        // DELETE: api/ClassificationAges/5
        [ResponseType(typeof(ClassificationAge))]
        public async Task<IHttpActionResult> DeleteClassificationAge(int id)
        {
            ClassificationAge classificationAge = await db.ClassificationAge.FindAsync(id);
            if (classificationAge == null)
            {
                return NotFound();
            }

            db.ClassificationAge.Remove(classificationAge);
            await db.SaveChangesAsync();

            return Ok(classificationAge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassificationAgeExists(int id)
        {
            return db.ClassificationAge.Count(e => e.IdClassificationAge == id) > 0;
        }
    }
}