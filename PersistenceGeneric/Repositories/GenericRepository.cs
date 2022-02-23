using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceGeneric.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            table = Context.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
            Context.SaveChanges();
        }

        public T Get(int id)
        {
            var entity = table.Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = table.ToList();
            return entities;
        }

        public void Remove(int id)
        {
            var entity = table.Find(id);
            table.Remove(entity);
            Context.SaveChanges();
        }
    }
}
