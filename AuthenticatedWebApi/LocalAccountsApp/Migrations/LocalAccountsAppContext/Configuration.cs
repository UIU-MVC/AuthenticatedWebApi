namespace LocalAccountsApp.Migrations.LocalAccountsAppContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiTest2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LocalAccountsApp.Models.LocalAccountsAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\LocalAccountsAppContext";
        }

        protected override void Seed(LocalAccountsApp.Models.LocalAccountsAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Departments.AddOrUpdate(
              p => p.Id,
              new Department { Name = "CSE" },
              new Department { Name = "EEE" },
              new Department { Name = "ECO" }
            );
            context.Students.AddOrUpdate(
              p => p.Id,
              new Student { Name = "Tanvir", DepartmentId = 1 },
              new Student { Name = "Saikat", DepartmentId = 1 },
              new Student { Name = "Jani na", DepartmentId = 2 }
            );
            context.Courses.AddOrUpdate(
              p => p.Id,
              new Course { Name = "C#", credit = 3 },
              new Course { Name = "java", credit = 3 },
              new Course { Name = "php", credit = 1 }
            );
            context.Enrollments.AddOrUpdate(
              p => p.Id,
              new Enrollment { StudentId = 3, CourseId = 1 }
            );
     
        }
    }
}
