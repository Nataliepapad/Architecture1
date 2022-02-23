using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceNoGeneric.Repositories;
using Entities.School;
using MyDatabase;
using PersistenceGeneric.Repositories;
using ProjectRepository = PersistenceGeneric.Repositories.ProjectRepository;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ProjectRepository projectService = new ProjectRepository(context);

            var projects = projectService.GetProjectsOrderBy();

            foreach (var pro in projects)
            {
                Console.WriteLine(pro.Title);
            }






            //GenericRepository<Project> projectService = new GenericRepository<Project>(context);
            //GenericRepository<Student> studentService = new GenericRepository<Student>(context);

            //var projects = projectService.GetAll();
            //foreach (var pro in projects)
            //{
            //    Console.WriteLine(pro.Title);
            //}
            //var students = studentService.GetAll();
            //foreach (var stu in students)
            //{
            //    Console.WriteLine(stu.Name);
            //}
        }
    }
}
