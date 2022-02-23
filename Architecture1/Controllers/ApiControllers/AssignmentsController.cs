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
using Entities.School;
using MyDatabase;
using PersistenceGeneric.Repositories;

namespace Architecture1.Controllers.ApiControllers
{
    public class AssignmentsController : ApiController
    {
        private ApplicationDbContext db;
        private AssignmentsRepository assignmentService;

        public AssignmentsController()
        {
            db = new ApplicationDbContext();
            assignmentService = new AssignmentsRepository(db);
        }

        // GET: api/Assignments
        public IHttpActionResult GetAssignments()
        {
            var assignments = assignmentService.GetAll().Select(t => new { t.Name });

            return Json(assignments);
        }

        // GET: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult GetAssignment(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssignment(int id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            db.Entry(assignment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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

        // POST: api/Assignments
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult PostAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assignments.Add(assignment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assignment.AssignmentId }, assignment);
        }

        // DELETE: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult DeleteAssignment(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }

            db.Assignments.Remove(assignment);
            db.SaveChanges();

            return Ok(assignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignmentExists(int id)
        {
            return db.Assignments.Count(e => e.AssignmentId == id) > 0;
        }
    }
}