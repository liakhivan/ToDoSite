using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ToDoSite.Domain.Entities
{
    public class TaskContext: DbContext
    {
        public TaskContext(): base("TaskDatabase")
        {}

        public DbSet<Task> Tasks { get; set; }
    }
}
