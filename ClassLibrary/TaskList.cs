using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TaskList
    {
        public string Name { get; set; }

        public List<Task> Tasks { get; set; }

        public int TasksCount
        {
            get
            {
                return Tasks.Count;
            }
        }

        public TaskList(string name, List<Task> tasks)
        {
            Name = name;
            Tasks = tasks;
        }
    }
}
