﻿using System;
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
    public class DestinationsController : ApiController
    {
        private Bovoyage3DbContext db = new Bovoyage3DbContext();

        // GET: api/Destinations
        // GET: api/Participants
        /// <summary>
        /// Retourne la liste des Destinations
        /// </summary>    
        public IQueryable<Destination> GetDestinations()
        {
            return db.Destinations;
        }

        // GET: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult GetDestination(int id)
        {
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        /// <summary>
        /// Ajoute une destination dans la base. Le nom est obligatoire
        /// </summary>
        /// <param pays="Destination"></param>
        /// <returns></returns>
        [Route("{pays}")]
        [ResponseType(typeof(Destination))]
        public IQueryable<Destination> GetDestination(string pays)
        {
            return db.Destinations.Where(x => x.Pays.Contains(pays));
        }

        // GET: api/destination/search
        [Route("api/destination/search")]
        public IHttpActionResult GetSearch(string continent = "", int? destinationId = null, string pays ="", string region ="", string description ="")
        {
            var query = db.Destinations.Where(x => !x.Deleted);

            if (!string.IsNullOrWhiteSpace(continent))
                query = query.Where(x => x.Continent.Contains(continent));

            Destination destination = db.Destinations.Find(destinationId);
            if (destinationId == null)
            {
                return NotFound();
            }

            if (destination.Id != destination.Id)
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(pays))
                query = query.Where(x => x.Pays.Contains(pays));
            if (pays == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrWhiteSpace(region))
                query = query.Where(x => x.Region.Contains(region));
            if(region == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(description))
                query = query.Where(x => x.Description.Contains(description));
            if (description == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // PUT: api/Destinations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestination(int id, Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destination.Id)
            {
                return BadRequest();
            }

            db.Entry(destination).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(id))
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

        // POST: api/Destinations
        [ResponseType(typeof(Destination))]
        public IHttpActionResult PostDestination(Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Destinations.Add(destination);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destination.Id }, destination);
        }

        // DELETE: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult DeleteDestination(int id)
        {
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return NotFound();
            }


            destination.Deleted = true;
            destination.DeletedAt = DateTime.Now;

            db.Entry(destination).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(destination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationExists(int id)
        {
            return db.Destinations.Count(e => e.Id == id) > 0;
        }
    }
}