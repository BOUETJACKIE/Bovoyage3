using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Bovoyage3.Data;
using Bovoyage3.Models;

namespace Bovoyage3.Controllers
{
    [RoutePrefix("api/agences")]
    public class AgenceVoyagesController : ApiController
    {
        private Bovoyage3DbContext db = new Bovoyage3DbContext();

        // GET: api/AgenceVoyages
        /// <summary>
        /// Retourne la liste des Agences de voyages
        /// </summary>  
        [Route("")]
        public IQueryable<AgenceVoyage> GetAgenceVoyages()
        {
            return db.AgenceVoyages;
        }

        // GET: api/AgenceVoyages/5
        /// <summary>
        /// recherche par l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [ResponseType(typeof(AgenceVoyage))]
        public IHttpActionResult GetAgenceVoyage(int id)
        {
            AgenceVoyage agenceVoyage = db.AgenceVoyages.Find(id);
            if (agenceVoyage == null)
            {
                return NotFound();
            }

            return Ok(agenceVoyage);
        }
        /// <summary>
        /// methode recherche par le nom ou le telephone
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Telephone"></param>
        /// <returns></returns>
        [Route("search")]
        public IQueryable<AgenceVoyage> GetSearch(string Nom = "",string Telephone="")
        {
            var query = db.AgenceVoyages.Where(x => !x.Deleted);

            if (!string.IsNullOrWhiteSpace(Nom))
                query = query.Where(x => x.Nom==Nom);

            if (!string.IsNullOrWhiteSpace(Telephone))
                query = query.Where(x => x.Telephone==Telephone);

            

            return query;
        }
        // PUT: api/AgenceVoyages/5
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenceVoyage(int id, AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenceVoyage.Id)
            {
                return BadRequest();
            }

            db.Entry(agenceVoyage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceVoyageExists(id))
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

        // POST: api/AgenceVoyages
        [Route("")]
        [ResponseType(typeof(AgenceVoyage))]
        public IHttpActionResult PostAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AgenceVoyages.Add(agenceVoyage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenceVoyage.Id }, agenceVoyage);
        }

        // DELETE: api/AgenceVoyages/5
        [Route("{id:int}")]
        [ResponseType(typeof(AgenceVoyage))]
        public IHttpActionResult DeletedVoyage(int id)
        {
            AgenceVoyage agencevoyage = db.AgenceVoyages.Find(id);
            if (agencevoyage == null)
            {
                return NotFound();
            }


            agencevoyage.Deleted = true;
            agencevoyage.DeletedAt = DateTime.Now;

            db.Entry(agencevoyage).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(agencevoyage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenceVoyageExists(int id)
        {
            return db.AgenceVoyages.Count(e => e.Id == id) > 0;
        }
    }
}