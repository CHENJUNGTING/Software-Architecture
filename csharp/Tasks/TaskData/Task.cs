using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Tasks.TaskData
{
    public class Task
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public DateTime DeadLine { get; set; }

        public DateTime Date { get; set; }
    }
}
