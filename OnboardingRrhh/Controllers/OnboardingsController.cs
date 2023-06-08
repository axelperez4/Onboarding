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

namespace OnboardingRrhh.Controllers
{
    public class OnboardingsController : ApiController
    {
        private DbOnboardingEntities db = new DbOnboardingEntities();

        // GET: api/Onboardings
        public IQueryable<ORTOnboarding> GetORTOnboarding()
        {
            return db.ORTOnboarding;
        }

        // GET: api/Onboardings/5
        [ResponseType(typeof(ORTOnboarding))]
        public IHttpActionResult GetORTOnboarding(int id)
        {
            ORTOnboarding oRTOnboarding = db.ORTOnboarding.Find(id);
            if (oRTOnboarding == null)
            {
                return NotFound();
            }

            return Ok(oRTOnboarding);
        }

        // PUT: api/Onboardings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORTOnboarding(int id, ORTOnboarding oRTOnboarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRTOnboarding.Id)
            {
                return BadRequest();
            }

            db.Entry(oRTOnboarding).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORTOnboardingExists(id))
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

        // POST: api/Onboardings
        [ResponseType(typeof(ORTOnboarding))]
        public IHttpActionResult PostORTOnboarding(ORTOnboarding oRTOnboarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORTOnboarding.Add(oRTOnboarding);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORTOnboardingExists(oRTOnboarding.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oRTOnboarding.Id }, oRTOnboarding);
        }

        // DELETE: api/Onboardings/5
        [ResponseType(typeof(ORTOnboarding))]
        public IHttpActionResult DeleteORTOnboarding(int id)
        {
            ORTOnboarding oRTOnboarding = db.ORTOnboarding.Find(id);
            if (oRTOnboarding == null)
            {
                return NotFound();
            }

            db.ORTOnboarding.Remove(oRTOnboarding);
            db.SaveChanges();

            return Ok(oRTOnboarding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORTOnboardingExists(int id)
        {
            return db.ORTOnboarding.Count(e => e.Id == id) > 0;
        }
    }
}