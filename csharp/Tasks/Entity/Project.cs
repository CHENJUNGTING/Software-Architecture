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

        public  ReadOnlyCollection<Task> GetTasks()
        {
            return _tasks.AsReadOnly();
        }

        public void AddTask(string description)
        {
            int id = TaskID.NextID();
            Task task = new Task(id, description,false);
            _tasks.Add(task);
        }

    }
}
