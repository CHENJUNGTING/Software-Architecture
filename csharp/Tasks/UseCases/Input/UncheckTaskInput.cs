using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Input
{
    class CheckTaskInput<T> : ICommandInput<T>
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
