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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Course> GetCoursesOrderBy()
        {
            return Context.Courses.OrderBy(x => x.Title).ToList();
        }
    }
}
