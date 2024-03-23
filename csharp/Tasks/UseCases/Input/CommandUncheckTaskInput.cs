using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Input
{
    public class CommandUncheckTaskInput : ICommandInput
    {
        private int ID;
        public int GetID()
        {
            return ID;
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }
    }
}
