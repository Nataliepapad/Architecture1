using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.School;
using Microsoft.AspNet.Identity.EntityFramework;
using Entities.IdentityUsers;
using MyDatabase.Initializers;

namespace MyDatabase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Sindesmos", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
    }
}
