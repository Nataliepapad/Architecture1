using Entities.School;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceNoGeneric.Repositories
{
    public class AssignmentRepository
    {
        protected readonly ApplicationDbContext Context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Assignment> GetAll()
        {
            return Context.Assignments.ToList();
        }

        public Assignment Get(int id)
        {
            var assignment = Context.Assignments.Find(id);
            return assignment;
        }

        public IEnumerable<Assignment> Find(Expression<Func<Assignment, bool>> predicate)
        {
            return Context.Assignments.Where(predicate);
        }

        public Assignment SingleOrDefault(Expression<Func<Assignment, bool>> predicate)
        {
            return Context.Assignments.SingleOrDefault(predicate);
        }


        public void Add(Assignment assignment)
        {
            Context.Assignments.Add(assignment);
            Context.SaveChanges();
        }
        public void AddRange(IEnumerable<Assignment> assignments)
        {
            Context.Assignments.AddRange(assignments);
            Context.SaveChanges();
        }
        public void Remove(Assignment assignment)
        {
            Context.Assignments.Remove(assignment);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var assignment = Context.Assignments.Find(id);
            if (assignment == null)
            {
                throw new ArgumentException("Trainer does not exist");
            }
            Context.Assignments.Remove(assignment);
            Context.SaveChanges();
        }
        public void RemoveChange(IEnumerable<Assignment> assignments)
        {
            Context.Assignments.RemoveRange(assignments);
            Context.SaveChanges();
        }

        public void Edit(Assignment assignment)
        {
            var assi = Context.Assignments.Find(assignment.AssignmentId);
            if (assi == null)
            {
                throw new ArgumentException("Assignment does not exist");
            }

            Context.Entry(assi).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
