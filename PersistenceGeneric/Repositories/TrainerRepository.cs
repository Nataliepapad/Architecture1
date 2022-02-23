using Entities.School;
using MyDatabase;
using PersistenceGeneric.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceGeneric.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Trainer> GetTrainersOrderBy()
        {
            return Context.Trainers.OrderBy(t => t.Name).ToList();
        }
    }
}

