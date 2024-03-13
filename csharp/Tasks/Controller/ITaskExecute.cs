using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;

namespace Tasks.Controller
{
    interface ITaskExecute
    {
        List<string> Execute(string command);
    }
}
