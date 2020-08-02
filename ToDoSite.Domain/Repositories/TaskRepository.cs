using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToDoSite.Domain.Abstruct;
using ToDoSite.Domain.Entities;

namespace ToDoSite.Domain.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        TaskContext dbContext;
        private bool disposed = false;

        public TaskRepository()
        {
            dbContext = new TaskContext();
        }
        public IEnumerable<Task> Tasks {
            get => dbContext.Tasks;
        }


        public void Create(Task item)
        {
            dbContext.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            Task task = dbContext.Tasks.Find(id);
            if (task != null)
                dbContext.Tasks.Remove(task); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task GetItem(int id)
        {
            return dbContext.Tasks.Find(id);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Task item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
