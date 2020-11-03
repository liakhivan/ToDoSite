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
        public bool IsComplete { get; set; }

        public Task()
        {}

        public Task(string name)
        {
            Name = name ?? throw new ArgumentNullException(Name);

            IsComplete = false;
        }
    }
}
