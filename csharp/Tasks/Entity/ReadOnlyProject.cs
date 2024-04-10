using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Entity
{
    public class ReadOnlyProject : Project
    {
        public ReadOnlyProject(ProjectName name, List<Task> tasks) : base(name, tasks) {

        }

        public override List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();  
            foreach(var task in _tasks)
            {
                tasks.Add(new ReadOnlyTask(task.GetId(), task.GetDescription(), task.IsDone()));
            }
            return tasks;
        }

    }
}
