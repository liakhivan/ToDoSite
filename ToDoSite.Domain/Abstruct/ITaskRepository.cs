using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoSite.Domain.Abstruct;
using ToDoSite.Domain.Entities;

namespace ToDoSite.Domain.Abstruct
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> Tasks { get; }
    }
}
