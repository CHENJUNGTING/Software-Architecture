using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Tasks.Entity
{
    public class Task
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
