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


        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        [HttpGet]
        public ActionResult Index(string type)
        { 
            return View(Filter(type));
        }

        [HttpPost]
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

        public RedirectResult DeleteCompletedTask()
        {
            IEnumerable<Task> tasks = taskRepository.Tasks;
            foreach (Task task in tasks)
            {
                if (!task.IsComplete)
                    continue;

                taskRepository.Delete(task.Id);
            }
            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }

        public RedirectResult ChangeStatus(int id)
        {
            Task task = taskRepository.GetItem(id);
            task.IsComplete = !task.IsComplete;
            taskRepository.Update(task);

            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }

        public RedirectResult ChangeAllStatuses(bool status)
        {
            IEnumerable<Task> tasks = taskRepository.Tasks;

            foreach (Task task in tasks)
            {
                task.IsComplete = status;
                taskRepository.Update(task);
            }

            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }

        public RedirectResult ChangeTaskName(int id, string name)
        {
            Task task = taskRepository.GetItem(id);
            task.Name = name;
            taskRepository.Update(task);

            taskRepository.SaveChanges();

            return new RedirectResult("/Task/Index");
        }


        private IEnumerable<Task> Filter(string taskFilter)
        {
            switch (taskFilter)
            {
                case "All":
                    return taskRepository.Tasks;
                case "Active":
                    return taskRepository.Tasks.Where(n => !n.IsComplete);
                case "Completed":
                    return taskRepository.Tasks.Where(n => n.IsComplete);
            }

            throw new ArgumentException();
        }
    }
}