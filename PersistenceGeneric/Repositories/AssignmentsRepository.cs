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
    public class AssignmentsRepository : GenericRepository<Assignment>, IAssignmetnRepository
    {
        public AssignmentsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Assignment> GetAssignmentsOrderBy()
        {
            return Context.Assignments.OrderBy(x => x.Name).ToList();
        }

        
    }
}
