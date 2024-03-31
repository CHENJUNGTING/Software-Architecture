using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Entity
{
    public class TaskId
    {
        public string Value { get; }

        private TaskId(string value)
        {
            Value = value;
        }

        public static TaskId Of(int id)
        {
            return new TaskId(id.ToString());
        }

        public static TaskId Of(string id)
        {
            return new TaskId(id);
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is TaskId id &&
                   Value == id.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(TaskId taskId_1, TaskId taskId_2)
        {
            return taskId_1.ToString() == taskId_2.ToString();
        }

        public static bool operator !=(TaskId taskId_1, TaskId taskId_2)
        {
            return taskId_1.ToString() != taskId_2.ToString();
        }


    }

}
