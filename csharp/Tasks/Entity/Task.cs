using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Tasks.Entity
{
    public class Task
    {
        private readonly TaskId id;
        private readonly string description;
        private bool done;

        public Task(TaskId Id, string description, bool done)
        {
            this.id = Id;
            this.description = description;
            this.done = done;
        }

        public TaskId GetId()
        {
            return id;
        }

        public string GetDescription()
        {
            return description;
        }


        public bool IsDone()
        {
            return done;
        }

        public virtual void SetDone(bool done)
        {
            this.done = done;
        }

    }
}
