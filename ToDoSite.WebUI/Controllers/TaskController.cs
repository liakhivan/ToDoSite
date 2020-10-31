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
        // GET: Task
        //public ActionResult Index()
        //{
        //    return View(taskRepository.Tasks);
        //}

        [HttpGet]
        public ActionResult Index(TaskFilter filter = TaskFilter.All)
        {
            this.filter = filter;
            switch (this.filter)
            {
                case TaskFilter.All:
                    return View(taskRepository.Tasks);
                case TaskFilter.Active:
                    return View(taskRepository.Tasks.Where(n => !n.IsComplete));
                case TaskFilter.Completed:
                    return View(taskRepository.Tasks.Where(n => n.IsComplete));
            }
            return View(taskRepository.Tasks);
        }



        public void CreateNewTask(string toDoText)
        {
            Task newTask = new Task(toDoText);
            taskRepository.Create(newTask);
            taskRepository.SaveChanges();

            Index(filter);
        }
    }
}