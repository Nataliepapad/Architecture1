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
    public class GradeRepository : GenericRepository<Course>, ICourseRepository
    {
        public GradeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Course> GetCoursesOrderBy()
        {
            throw new NotImplementedException();
        }
    }
}
