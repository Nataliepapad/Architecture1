using Entities.School;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace PersistenceNoGeneric.Repositories
{
    public class CourseRepository
    {
        protected readonly ApplicationDbContext Context;
        public CourseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = Context.Courses;

            return courses.ToList();
        }

        public Course Get(int id)
        {
            var courses = Context.Courses.Find(id);
            return courses;
        }

        public IEnumerable<Course> Find(Expression<Func<Course, bool>> predicate)
        {
            return Context.Courses.Where(predicate);
        }
        public Course SingleOrDefault(Expression<Func<Course, bool>> predicate)
        {
            return Context.Courses.SingleOrDefault(predicate);
        }
        public void Add(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
        }
        public void AddRange(IEnumerable<Course> course)
        {
            Context.Courses.AddRange(course);
            Context.SaveChanges();
        }
        public void Remove(Course course)
        {
            Context.Courses.Remove(course);
            Context.SaveChanges();
        }
        public void Remove(int id)
        {
            var course = Context.Courses.Find(id);
            if (course == null)
            {
                throw new ArgumentException("Project does not exist");
            }
            Context.Courses.Remove(course);
            Context.SaveChanges();
        }
        public void RemoveChange(IEnumerable<Course> courses)
        {
            Context.Courses.RemoveRange(courses);
            Context.SaveChanges();
        }
        public void Edit(Course course)
        {
            var cou = Context.Courses.Find(course.CourseId);
            if (cou == null)
            {
                throw new ArgumentException("Course does not exist");
            }

            Context.Entry(cou).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
