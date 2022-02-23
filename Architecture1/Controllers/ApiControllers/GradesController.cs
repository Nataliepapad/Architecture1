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
    public class GradesController : ApiController
    {
        private ApplicationDbContext db;
        private GradeRepository gradeService;

        public GradesController()
        {
            db = new ApplicationDbContext();
            gradeService = new GradeRepository(db);
        }

        // GET: api/Grades
        public IHttpActionResult GetGrades()
        {
            var grades = gradeService.GetAll()
                .Select(g => new
                {
                    g.Type
                }); ;
            return Json(grades);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}