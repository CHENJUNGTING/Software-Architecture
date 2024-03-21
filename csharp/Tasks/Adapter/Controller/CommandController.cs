using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public interface CommandController
    {
        public CommandReturnMessage execute(string consoleCommand);
    }
}
