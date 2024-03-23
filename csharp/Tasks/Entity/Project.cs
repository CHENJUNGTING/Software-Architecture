using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tasks.Entity
{
    public class Project
    {
        private ProjectName _name;
        private readonly List<Task> _tasks;

        public Project(ProjectName name, List<Task> tasks)
        {
            this._name = name;
            this._tasks = tasks;
        }

        public ProjectName getName()
        {
            return _name;
        }

        public List<Task> getTasks()
        {
            return _tasks;
        }


    }
}
