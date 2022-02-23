using Entities.School;
using MyDatabase;
using PersistenceGeneric.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceGeneric.Repositories
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Grade> GetGradesOrderBy()
        {
            var gradesOrdered = Context.Grades.OrderBy(g=>g.Type);
            return gradesOrdered;
        }
    }
}
