using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;

namespace Tasks.Entity
{
    public class Task
    {
        public Task(int id, string description, bool done)
        {
            Id = id;
            Description = description;
            Done = done;
        }

        public int Id { get;}

        public string Description { get; private set; }

        public bool Done { get;private set; }

        public void SetDescription(string description)
        {
            this.Description = description;
        }

        public void SetDone(bool done)
        {
            this.Done = done;
        }
    }
}
