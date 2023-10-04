using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToDoList
{
    public class ApplicationContext : DbContext
    {
       /*"Server=localhost;Port=5432;Database=ToDoList;User Id=postgres;Password=0405;"*/
        public ApplicationContext() : base(nameOrConnectionString: "DbConnection")
        {

        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
