using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDatabase;
using Entities.School;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PersistenceNoGeneric.Repositories
{
    public class StudentRepository
    {
        protected readonly ApplicationDbContext Context;
        public StudentRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return Context.Students.ToList();
        }
        public Student Get(int id)
        {
            var student = Context.Students.Find(id);
            return student;
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return Context.Students.Where(predicate);
        }
        public Student SingleOrDefault(Expression<Func<Student, bool>> predicate)
        {
            return Context.Students.SingleOrDefault(predicate);
        }
        public IEnumerable<IGrouping<ICollection<Project>, Student>> GroupByProjects()
        {
            var students = from st in Context.Students
                           group st by st.Projects into g
                           select g;
            return students.ToList();
        }
        public void Add(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
        }
        public void AddRange(IEnumerable<Student> students)
        {
            Context.Students.AddRange(students);
            Context.SaveChanges();
        }
        public void Remove(Student student)
        {
            Context.Students.Remove(student);
            Context.SaveChanges();
        }
        public void Remove(int id)
        {
            var student = Context.Students.Find(id);
            if (student == null)
            {
                throw new ArgumentException("Student does not exist");
            }
            Context.Students.Remove(student);
            Context.SaveChanges();
        }
        public void RemoveChange(IEnumerable<Student> students)
        {
            Context.Students.RemoveRange(students);
            Context.SaveChanges();
        }

        public void Edit(Student student)
        {
            var stu = Context.Students.Find(student.StudentId);
            if (stu == null)
            {
                throw new ArgumentException("Student does not exist");
            }

            Context.Entry(stu).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void AssignProjectToStudent(IEnumerable<Project> projects,Student students)
        {
            throw new NotImplementedException("Tha tin kanei o mpampis");
        }
    }
}
