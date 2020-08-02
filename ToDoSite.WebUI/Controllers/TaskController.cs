using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoSite.Domain.Abstruct;

namespace ToDoSite.WebUI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        // GET: Task
        public ActionResult Index()
        {

            return View(taskRepository.Tasks);
        }
    }
}