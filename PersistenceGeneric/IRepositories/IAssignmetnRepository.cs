using Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersistenceGeneric.IRepositories
{
    public interface IAssignmetnRepository : IGenericRepository<Assignment>
    {
        IEnumerable<Assignment> GetAssignmentsOrderBy();
    }
}
