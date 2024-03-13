using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskListData
    {
        private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        public IDictionary<string, IList<Task>> GetTasks()
        {
            return tasks;
        }
        
    }
}
