using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Message;

namespace Tasks.Adapter
{
    interface ITaskExecute
    {
        public CommandReturnMessage ExecuteTask(string command);
    }
}
