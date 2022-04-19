using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Application
    {
        private static Application application { get; set; }

        public List<TaskList> TaskLists { get; set; }

        private Application()
        {
            List<Task> tasks1 = new List<Task>()
            {
                new Task("Сделать математику",DateTime.Now),
                new Task("Сделать физику",DateTime.Now),
                new Task("Сделать информатику",DateTime.Now)
            };

            List<Task> tasks2 = new List<Task>()
            {
                new Task("Позвонить клиенту",DateTime.Now),
                new Task("Сделать отчет",DateTime.Now, true),
                new Task("Составить список конкурентов",DateTime.Now),
                new Task("Составить бизнесплан",DateTime.Now)
            };

            TaskLists = new List<TaskList>()
            {
                new TaskList("Учеба",tasks1),
                new TaskList("Работа", tasks2)
            };
        }

        public static Application GetApplication()
        {
            if(application == null)
            {
                application = new Application();
            }
            return application;
        }


    }
}
