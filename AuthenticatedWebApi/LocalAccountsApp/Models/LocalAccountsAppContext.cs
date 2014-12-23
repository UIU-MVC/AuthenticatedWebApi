using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocalAccountsApp.Models
{
    public class LocalAccountsAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LocalAccountsAppContext() : base("name=LocalAccountsAppContext")
        {
        }

        public System.Data.Entity.DbSet<WebApiTest2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<WebApiTest2.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<WebApiTest2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<WebApiTest2.Models.Enrollment> Enrollments { get; set; }
    
    }
}
