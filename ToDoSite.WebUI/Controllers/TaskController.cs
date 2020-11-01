using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using ToDoSite.Domain.Abstruct;
using ToDoSite.Domain.Entities;

namespace ToDoSite.WebUI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;

        TaskFilter filter = TaskFilter.All;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        [HttpGet]
        public ActionResult Index()
        { 
            return View(Filter(filter));
        }



        public RedirectResult CreateNewTask(string toDoText)
        {
            Task newTask = new Task(toDoText);
            taskRepository.Create(newTask);
            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }


        [HttpPost]
        public RedirectResult DeleteTask(int id)
        {
            taskRepository.Delete(id);
            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }


        private IEnumerable<Task> Filter(TaskFilter taskFilter)
        {
            switch (this.filter)
            {
                case TaskFilter.All:
                    return taskRepository.Tasks;
                case TaskFilter.Active:
                    return taskRepository.Tasks.Where(n => !n.IsComplete);
                case TaskFilter.Completed:
                    return taskRepository.Tasks.Where(n => n.IsComplete);
            }

            throw new ArgumentException();
        }
    }
}