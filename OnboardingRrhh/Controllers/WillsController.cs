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
using OnboardingRrhh.DbContext;
using OnboardingRrhh.Models;

namespace OnboardingRrhh.Controllers
{
    public class WillsController : ApiController
    {
        private DbOnboardingEntities db = new DbOnboardingEntities();

        // GET: api/Wills
        public List<WillVM> GetORTWill()
        {
            return db.ORTWill.Where(x => x.Activo).Select(x => new WillVM
            {
                Id = x.Id,
                Will = x.Will,
                Peso = x.Peso,
                Descripcion = x.Descripcion,
                PorDefecto = x.PorDefecto
            }).ToList();
        }

        // GET: api/Wills/5
        [ResponseType(typeof(ORTWill))]
        public IHttpActionResult GetWill(int id)
        {
            ORTWill oRTWill = db.ORTWill.Find(id);
            if (oRTWill == null)
            {
                return NotFound();
            }

            return Ok(oRTWill);
        }

        // PUT: api/Wills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORTWill(int id, ORTWill oRTWill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRTWill.Id)
            {
                return BadRequest();
            }

            db.Entry(oRTWill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORTWillExists(id))
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

        // POST: api/Wills
        [ResponseType(typeof(ORTWill))]
        public IHttpActionResult PostORTWill(ORTWill oRTWill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORTWill.Add(oRTWill);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORTWillExists(oRTWill.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oRTWill.Id }, oRTWill);
        }

        // DELETE: api/Wills/5
        [ResponseType(typeof(ORTWill))]
        public IHttpActionResult DeleteORTWill(int id)
        {
            ORTWill oRTWill = db.ORTWill.Find(id);
            if (oRTWill == null)
            {
                return NotFound();
            }

            db.ORTWill.Remove(oRTWill);
            db.SaveChanges();

            return Ok(oRTWill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORTWillExists(int id)
        {
            return db.ORTWill.Count(e => e.Id == id) > 0;
        }
    }
}