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
    public class ExemplairesController : ApiController
    {
        private MediathequeEntities db = new MediathequeEntities();

        // GET: api/Exemplaires
        public IQueryable<Exemplaire> GetExemplaire()
        {
            return db.Exemplaire;
        }

        // GET: api/Exemplaires/5
        [ResponseType(typeof(Exemplaire))]
        public async Task<IHttpActionResult> GetExemplaire(int id)
        {
            Exemplaire exemplaire = await db.Exemplaire.FindAsync(id);
            if (exemplaire == null)
            {
                return NotFound();
            }

            return Ok(exemplaire);
        }

        // PUT: api/Exemplaires/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExemplaire(int id, Exemplaire exemplaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exemplaire.IdExemplaire)
            {
                return BadRequest();
            }

            db.Entry(exemplaire).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExemplaireExists(id))
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

        // POST: api/Exemplaires
        [ResponseType(typeof(Exemplaire))]
        public async Task<IHttpActionResult> PostExemplaire(Exemplaire exemplaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exemplaire.Add(exemplaire);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exemplaire.IdExemplaire }, exemplaire);
        }

        // DELETE: api/Exemplaires/5
        [ResponseType(typeof(Exemplaire))]
        public async Task<IHttpActionResult> DeleteExemplaire(int id)
        {
            Exemplaire exemplaire = await db.Exemplaire.FindAsync(id);
            if (exemplaire == null)
            {
                return NotFound();
            }

            db.Exemplaire.Remove(exemplaire);
            await db.SaveChangesAsync();

            return Ok(exemplaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExemplaireExists(int id)
        {
            return db.Exemplaire.Count(e => e.IdExemplaire == id) > 0;
        }
        

        // Livres par id
        public async Task<List<DetailsExemplaire>> Get_Exemplaire(int idExemplaire)
        {
            List<Exemplaire> exemplaire = await (from m in db.Exemplaire where m.IdExemplaire == idExemplaire select m).ToListAsync();

            List<DetailsExemplaire> listeAffichages = new List<DetailsExemplaire>();

            foreach (Exemplaire item in exemplaire)
            {
                DetailsExemplaire detailsExemplaire = new DetailsExemplaire();
                detailsExemplaire.IdDocument = item.IdDocument;
                detailsExemplaire.Titre = item.Document.Titre;
                detailsExemplaire.ISNB = item.Document.ISNB;
                detailsExemplaire.LibelleClassification = item.Document.ClassificationAge.LibelleClassification;
                detailsExemplaire.AgeMinimum = item.Document.ClassificationAge.AgeMinimum;
                detailsExemplaire.LibelleStatutExemplaire = item.StatutExemplaire.LibelleStatutExemplaire;
                detailsExemplaire.LibelleTypeDocument = item.Document.TypeDocument.LibelleTypeDocument;
                detailsExemplaire.DateEmprunt = item.DateEmprunt;
                detailsExemplaire.NomUsager = item.Usager.NomUsager;
                detailsExemplaire.PrenomUsager = item.Usager.PrenomUsager;
                detailsExemplaire.Adresse = item.Usager.Coordonnees.Adresse;
                detailsExemplaire.DateNaissance = item.Usager.DateNaissance;
                detailsExemplaire.LibelleTypeAbonnement = item.Usager.TypeAbonnement.LibelleTypeAbonnement;

                listeAffichages.Add(detailsExemplaire);
            }
            return listeAffichages;
        }
        

        // Livres par id sans liste
        [ResponseType(typeof(DetailsExemplaire))]
        public async Task<IHttpActionResult> Get_Exemplaire2(int id, string token)
        {
            Exemplaire exemplaire = await db.Exemplaire.FindAsync(id);

            DetailsExemplaire detailsExemplaire = new DetailsExemplaire();
            detailsExemplaire.IdDocument = exemplaire.IdDocument;
            detailsExemplaire.Titre = exemplaire.Document.Titre;
            detailsExemplaire.ISNB = exemplaire.Document.ISNB;
            detailsExemplaire.LibelleClassification = exemplaire.Document.ClassificationAge.LibelleClassification;
            detailsExemplaire.AgeMinimum = exemplaire.Document.ClassificationAge.AgeMinimum;
            detailsExemplaire.LibelleStatutExemplaire = exemplaire.StatutExemplaire.LibelleStatutExemplaire;
            detailsExemplaire.LibelleTypeDocument = exemplaire.Document.TypeDocument.LibelleTypeDocument;
            detailsExemplaire.DateEmprunt = exemplaire.DateEmprunt;
            detailsExemplaire.NomUsager = exemplaire.Usager.NomUsager;
            detailsExemplaire.PrenomUsager = exemplaire.Usager.PrenomUsager;
            detailsExemplaire.Adresse = exemplaire.Usager.Coordonnees.Adresse;
            detailsExemplaire.DateNaissance = exemplaire.Usager.DateNaissance;
            detailsExemplaire.LibelleTypeAbonnement = exemplaire.Usager.TypeAbonnement.LibelleTypeAbonnement;

            return Ok(detailsExemplaire);
        }
                
    }
}
