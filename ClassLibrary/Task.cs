using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Task
    {

        public string Title { get; set; }

        public DateTime Due { get; set; }

        public string DisplayDue
        {
            get
            {
                return Due.ToString("dd.mm.yyyy");
            }
        }

        public Boolean Done { get; set; }

        public Task(string title, DateTime due)
        {
            Title = title;
            Due = due;

        }

        public Task(string title, DateTime due, Boolean done)
        {
            Title = title;
            Due = due;
            Done = done;
        }

    }
}
