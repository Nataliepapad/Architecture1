using MyDatabase;
using PersistenceNoGeneric.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Architecture1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        ApplicationDbContext db;
        StudentRepository studentService;

        public StudentController()
        {
            db = new ApplicationDbContext();
            studentService = new StudentRepository(db);
        }

        public ActionResult Index()
        {
            var students = studentService.GetAll();
            
            return View(students);
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