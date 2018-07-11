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
    [RoutePrefix("api/clients")]
    public class ClientsController : ApiController
    {
        private Bovoyage3DbContext db = new Bovoyage3DbContext();

        // GET: api/Clients   
        /// <summary>
        /// Retourne la liste des Clients
        /// </summary>   
        [Route("")]
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients/5
        [Route("{id:int}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClients(int id)

        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>
        /// Ajoute un client dans la base. Le nom est obligatoire
        /// </summary>
        /// <param nom="client"></param>
        /// <returns></returns>
        [Route("{nom}")]
        [ResponseType(typeof(Client))]
        public IQueryable<Client> GetClients(string nom)
        {
            return db.Clients.Where(x => x.Nom.Contains(nom));
        }

        // GET: api/Clients/search
        [Route("search")]
        public IHttpActionResult GetSearch(string nom = "", int? personneId = null, string telephone ="")
        {
            var query = db.Clients.Where(x => !x.Deleted);
            if (!string.IsNullOrWhiteSpace(nom))
                query = query.Where(x => x.Nom==nom);
            if(nom == null)
            {
                return NotFound();
            }

           /* if (personneId != null)
                query = query.Where(x => x.Personne.Id == personneId);
            if (personneId == null)
            {
                return BadRequest();
            }
            */
            var query2 = db.Clients.Where(x => !x.Deleted);
            if (!string.IsNullOrWhiteSpace(telephone))
                query = query.Where(x => x.Telephone==telephone);
            if(telephone == null)
            {
                return NotFound();
            }

            return Ok();
        }
        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        /// <summary>
        /// Ajoute un client dans la base. Le nom est obligatoire
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        // POST: api/Clients
        [Route("")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }


            client.Deleted = true;
            client.DeletedAt = DateTime.Now;

            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(client);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}