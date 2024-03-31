using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskListId
    {
        public string Value { get; }

        private TaskListId(string value)
        {
            Value = value;
        }

        public static TaskListId Of(string id)
        {
            return new TaskListId(id);
        }
    }
}
