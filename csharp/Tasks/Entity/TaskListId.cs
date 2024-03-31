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

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is TaskListId id &&
                   Value == id.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(TaskListId taskListId_1, TaskListId taskListId_2)
        {
            return taskListId_1.ToString() == taskListId_2.ToString();
        }

        public static bool operator !=(TaskListId taskListId_1, TaskListId taskListId_2)
        {
            return taskListId_1.ToString() != taskListId_2.ToString();
        }

    }
}
