using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class ReadOnlyProject : Project
    {
        public ReadOnlyProject(ProjectName name, List<Task> tasks) :base(name, tasks) { 

        }

    }
}
