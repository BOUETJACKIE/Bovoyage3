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
    public class AssuranceAnulationsController : ApiController
    {
        private Bovoyage3DbContext db = new Bovoyage3DbContext();

        // GET: api/AssuranceAnulations
        /// <summary>
        /// Retourne la liste des Assurances
        /// </summary>    
        public IQueryable<AssuranceAnulation> GetAssuranceAnulations()
        {
            return db.AssuranceAnulations;
        }

        // GET: api/AssuranceAnulations/5
        [ResponseType(typeof(AssuranceAnulation))]
        public IHttpActionResult GetAssuranceAnulation(int id)
        {
            AssuranceAnulation assuranceAnulation = db.AssuranceAnulations.Find(id);
            if (assuranceAnulation == null)
            {
                return NotFound();
            }

            return Ok(assuranceAnulation);
        }

        // PUT: api/AssuranceAnulations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssuranceAnulation(int id, AssuranceAnulation assuranceAnulation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assuranceAnulation.Id)
            {
                return BadRequest();
            }

            db.Entry(assuranceAnulation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuranceAnulationExists(id))
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

        // POST: api/AssuranceAnulations
        [ResponseType(typeof(AssuranceAnulation))]
        public IHttpActionResult PostAssuranceAnulation(AssuranceAnulation assuranceAnulation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssuranceAnulations.Add(assuranceAnulation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assuranceAnulation.Id }, assuranceAnulation);
        }

        // DELETE: api/AssuranceAnulations/5
        [ResponseType(typeof(AssuranceAnulation))]
        public IHttpActionResult DeleteAssuranceAnnulation(int id)
        {
            AssuranceAnulation assuranceAnulation  = db.AssuranceAnulations.Find(id);
            if (assuranceAnulation == null)
            {
                return NotFound();
            }


            assuranceAnulation.Deleted = true;
            assuranceAnulation.DeletedAt = DateTime.Now;

            db.Entry(assuranceAnulation).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(assuranceAnulation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssuranceAnulationExists(int id)
        {
            return db.AssuranceAnulations.Count(e => e.Id == id) > 0;
        }
    }
}