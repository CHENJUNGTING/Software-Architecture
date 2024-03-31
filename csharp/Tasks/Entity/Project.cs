using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tasks.Entity
{
    public class Project
    {
        private readonly ProjectName _name;
        private readonly List<Task> _tasks;

        public Project(ProjectName name, List<Task> tasks)
        {
            _name = name;
            _tasks = tasks;
        }

        public ProjectName GetName()
        {
            return _name;
        }

        public List<Task> GetTasks()
        {
            return _tasks;
        }

        public void AddTask(TaskId taskId, string description, bool done)
        {
            Task task = new Task(taskId, description,done);
            _tasks.Add(task);
        }

    }
}
