using Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        ApplicationDbContext db;
        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }

        public void SeedStudent()
        {
            Student s1 = new Student() { Name = "Hector", Age = 34 };
            Student s2 = new Student() { Name = "Mpampis", Age = 33 };
            Student s3 = new Student() { Name = "Lakis", Age = 30 };
            Student s4 = new Student() { Name = "Fanis", Age = 45 };

            Project p1 = new Project() { Title = "CSharp" };
            Project p2 = new Project() { Title = "Python" };
            Project p3 = new Project() { Title = "Java" };
            Project p4 = new Project() { Title = "JavaScript" };

            p1.Student = s1;
            p2.Student = s2;
            p3.Student = s3;
            p4.Student = s4;

            db.Projects.Add(p1);
            db.Projects.Add(p2);
            db.Projects.Add(p3);
            db.Projects.Add(p4);

            db.Students.Add(s1);
            db.Students.Add(s2);
            db.Students.Add(s3);
            db.Students.Add(s4);

            db.SaveChanges();
        }

        public void SeedCourse()
        {
            Course c1 = new Course() { Title = "C++ CB8", Duration = 60 };
            Course c2 = new Course() { Title = "JAVA CB7", Duration = 80 };
            Course c3 = new Course() { Title = "C# CB9", Duration = 70 };
            Course c4 = new Course() { Title = "Javascript CB9", Duration = 120 };

            db.Courses.Add(c1);
            db.Courses.Add(c2);
            db.Courses.Add(c3);
            db.Courses.Add(c4);
        }

        public void SeedGrades()
        {
            Grade g1 = new Grade() { Type = "Theoretical" };
            Grade g2 = new Grade() { Type = "Practical" };

            db.Grades.Add(g1);
            db.Grades.Add(g2);

            db.SaveChanges();
        }

        public void SeedAssignmets()
        {
            Assignment a1 = new Assignment() { Name = "C#" };
            Assignment a2 = new Assignment() { Name = "Html" };
            Assignment a3 = new Assignment() { Name = "Java" };

            db.Assignments.Add(a1);
            db.Assignments.Add(a2);
            db.Assignments.Add(a3);

            db.SaveChanges();
        }
    }
}
