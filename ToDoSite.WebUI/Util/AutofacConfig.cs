using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using ToDoSite.Domain.Repositories;
using ToDoSite.Domain.Abstruct;

namespace ToDoSite.WebUI.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // Отримуємо екземпляр контейнера.
            var builder = new ContainerBuilder();

            // Реєструємо контроллер в поточній збірці.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Реєструємо співставлення типів.
            builder.RegisterType<TaskRepository>().As<ITaskRepository>();

            // Створюємо новий контейнер з тими залежностями, які оголошені вище.
            var container = builder.Build();

            // Встановлення співставлювача залежностей.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}