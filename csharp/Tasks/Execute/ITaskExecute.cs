using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Command;

namespace Tasks.Execute
{
    interface ITaskExecute
    {
        List<string> Execute(string command);
    }
}
