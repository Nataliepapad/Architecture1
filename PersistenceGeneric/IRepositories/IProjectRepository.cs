using Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceGeneric.IRepositories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        IEnumerable<Project> GetProjectsOrderBy();
    }
}
