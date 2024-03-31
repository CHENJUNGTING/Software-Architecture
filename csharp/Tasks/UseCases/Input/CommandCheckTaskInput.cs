using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCases.Input
{
    public class CommandCheckTaskInput : ICommandInput
    {
        private TaskId ID;
        public int GetID()
        {
            return Convert.ToInt32(ID.Value);
        }
        public void SetID(int ID)
        {
            this.ID = TaskId.Of(ID);
        }
    }
}
