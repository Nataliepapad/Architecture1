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
    public class TrainerRepository
    {
        protected readonly ApplicationDbContext Context;
        public TrainerRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return Context.Trainers.ToList();
        }
        public Trainer Get(int id)
        {
            var trainer = Context.Trainers.Find(id);
            return trainer;
        }
        public IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> predicate)
        {
            return Context.Trainers.Where(predicate);
        }
        public Trainer SingleOrDefault(Expression<Func<Trainer, bool>> predicate)
        {
            return Context.Trainers.SingleOrDefault(predicate);
        }

        public void Add(Trainer trainer)
        {
            Context.Trainers.Add(trainer);
            Context.SaveChanges();
        }
        public void AddRange(IEnumerable<Trainer> trainers)
        {
            Context.Trainers.AddRange(trainers);
            Context.SaveChanges();
        }
        public void Remove(Trainer trainer)
        {
            Context.Trainers.Remove(trainer);
            Context.SaveChanges();
        }
        public void Remove(int id)
        {
            var trainer = Context.Trainers.Find(id);
            if (trainer == null)
            {
                throw new ArgumentException("Trainer does not exist");
            }
            Context.Trainers.Remove(trainer);
            Context.SaveChanges();
        }
        public void RemoveChange(IEnumerable<Trainer> trainers)
        {
            Context.Trainers.RemoveRange(trainers);
            Context.SaveChanges();
        }

        public void Edit(Trainer trainer)
        {
            var tr = Context.Trainers.Find(trainer.TrainerId);
            if (tr == null)
            {
                throw new ArgumentException("Trainer does not exist");
            }

            Context.Entry(tr).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
