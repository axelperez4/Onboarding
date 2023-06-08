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
    public class SkillsController : ApiController
    {
        private DbOnboardingEntities db = new DbOnboardingEntities();

        // GET: api/Skills
        public List<SkillVM> GetORTSkill()
        {
            return db.ORTSkill.Where(x => x.Activo).Select(x => new SkillVM
            {
                Id = x.Id,
                Skill = x.ORTRamaSkill.Descripcion,
                Descripcion = x.Descripcion,
                PorDefecto = x.PorDefecto
            }
                ).ToList();
        }

        // GET: api/Skills
        [Route("api/getRamasSkill")]
        public List<RamaSkillVM> GetRamaSkill()
        {
            return db.ORTRamaSkill.Where(x => x.Activo).Select(x => new RamaSkillVM
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
            }
                ).ToList();
        }

        // GET: api/Skills/5
        [ResponseType(typeof(ORTSkill))]
        public IHttpActionResult GetORTSkill(int id)
        {
            ORTSkill oRTSkill = db.ORTSkill.Find(id);
            if (oRTSkill == null)
            {
                return NotFound();
            }

            return Ok(oRTSkill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORTSkill(int id, ORTSkill oRTSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRTSkill.Id)
            {
                return BadRequest();
            }

            db.Entry(oRTSkill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORTSkillExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(ORTSkill))]
        public IHttpActionResult PostORTSkill(ORTSkill ortSkill)
        {
            ortSkill.FechaCreacion = DateTime.Now;
            ortSkill.UsuarioCreacion = 10001; //Utilizar usuario mandado desde FE en situación real
            ortSkill.Activo = true;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORTSkill.Add(ortSkill);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORTSkillExists(ortSkill.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ortSkill.Id }, ortSkill);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(ORTSkill))]
        public IHttpActionResult DeleteORTSkill(int id)
        {
            ORTSkill oRTSkill = db.ORTSkill.Find(id);
            if (oRTSkill == null)
            {
                return NotFound();
            }

            db.ORTSkill.Remove(oRTSkill);
            db.SaveChanges();

            return Ok(oRTSkill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORTSkillExists(int id)
        {
            return db.ORTSkill.Count(e => e.Id == id) > 0;
        }

        public bool ValidarSkill(ORTSkill skill)
        {
            if (skill.IdRamaSkill != 0 &&
                skill.UsuarioCreacion > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}