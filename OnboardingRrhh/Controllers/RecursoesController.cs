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
    public class RecursoesController : ApiController
    {
        private DbOnboardingEntities db = new DbOnboardingEntities();

        // GET: api/Recursoes
        public List<RecursoVM> GetORTRecurso()
        {
            return db.ORTRecurso.Where(x => x.Activo).Select(x => new RecursoVM
            {
                Id = x.Id,
                Responsable = x.Responsable,
                Descripcion = x.Descripcion,
                PorDefecto = x.PorDefecto
            }).ToList()
                ;
        }

        // GET: api/Recursoes/5
        [ResponseType(typeof(ORTRecurso))]
        public IHttpActionResult GetORTRecurso(int id)
        {
            ORTRecurso oRTRecurso = db.ORTRecurso.Find(id);
            if (oRTRecurso == null)
            {
                return NotFound();
            }

            return Ok(oRTRecurso);
        }

        // PUT: api/Recursoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORTRecurso(int id, ORTRecurso oRTRecurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRTRecurso.Id)
            {
                return BadRequest();
            }

            db.Entry(oRTRecurso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORTRecursoExists(id))
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

        // POST: api/Recursoes
        [ResponseType(typeof(ORTRecurso))]
        public IHttpActionResult PostORTRecurso(ORTRecurso oRTRecurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORTRecurso.Add(oRTRecurso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORTRecursoExists(oRTRecurso.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oRTRecurso.Id }, oRTRecurso);
        }

        // DELETE: api/Recursoes/5
        [ResponseType(typeof(ORTRecurso))]
        public IHttpActionResult DeleteORTRecurso(int id)
        {
            ORTRecurso oRTRecurso = db.ORTRecurso.Find(id);
            if (oRTRecurso == null)
            {
                return NotFound();
            }

            db.ORTRecurso.Remove(oRTRecurso);
            db.SaveChanges();

            return Ok(oRTRecurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORTRecursoExists(int id)
        {
            return db.ORTRecurso.Count(e => e.Id == id) > 0;
        }
    }
}