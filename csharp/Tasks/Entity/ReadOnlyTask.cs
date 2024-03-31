using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class ReadOnlyTask : Task
    {
        public ReadOnlyTask(TaskId taskId, string description, bool done):base(taskId,description,done) { 
        }
        public void SetDone(bool done)
        {
            throw new Exception("Cannot modify task because it is readonly");
        }


    }
}
