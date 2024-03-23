using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class ShowController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandShow commandShow = new CommandShow();
            CommandShowInput showInput = new CommandShowInput();
            commandReturnMessage = commandShow.Execute(showInput);
            return commandReturnMessage;
        }
    }
}
