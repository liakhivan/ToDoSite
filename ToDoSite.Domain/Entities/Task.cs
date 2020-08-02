using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace ToDoSite.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }

        public Task()
        {}

        public Task(string name, int priority)
        {
            Name = name ?? throw new ArgumentNullException(Name);

            if (priority <= 0)
                throw new ArgumentException();
            IsActive = true;
            Priority = priority;
        }
    }
}
