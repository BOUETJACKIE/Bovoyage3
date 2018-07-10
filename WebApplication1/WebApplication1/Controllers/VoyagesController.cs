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
    public class VoyagesController : ApiController
    {
        private Bovoyage3DbContext db = new Bovoyage3DbContext();

        // GET: api/Voyages
        // GET: api/Participants
        /// <summary>
        /// Retourne la liste des Voyages
        /// </summary>    
        public IQueryable<Voyage> GetVoyages()
        {
            return db.Voyages.Include(x=>x.Destination).Where(x=>!x.Deleted);
        }

        // GET: api/Voyages/5
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult GetVoyage(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            return Ok(voyage);
        }
        [Route("api/voyages/search")]
        public IQueryable<Voyage> GetSearch(DateTime? DateAller= null, DateTime? DateRetour= null, int? PlaceDispo= null, decimal? TarifToutCompris= null )
        {
            var query = db.Voyages.Where(x => !x.Deleted);

            if (TarifToutCompris != null)
                query = query.Where(x => x.TarifToutCompris != 0);
            if (DateAller != null)
                query = query.Where(x => x.DateAller > DateTime.Now);

            if (DateRetour != null)
                query = query.Where(x => x.DateRetour> DateTime.Now);

            if (PlaceDispo != null)
                query = query.Where(x => x. PlacesDispo != 0);

            return query;
        }
        // PUT: api/Voyages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoyage(int id, Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voyage.Id)
            {
                return BadRequest();
            }

            db.Entry(voyage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(id))
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

        // POST: api/Voyages
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult PostVoyage(Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voyages.Add(voyage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voyage.Id }, voyage);
        }

        // DELETE: api/Voyages/5

        [ResponseType(typeof(Voyage))]
        public IHttpActionResult DeleteVoyage(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            
            voyage.Deleted = true;
            voyage.DeletedAt = DateTime.Now;

            db.Entry(voyage).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(voyage);
        }


       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoyageExists(int id)
        {
            return db.Voyages.Count(e => e.Id == id) > 0;
        }
    }
}