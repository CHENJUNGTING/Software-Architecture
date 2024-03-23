using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class HelpController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandShow commandHelp = new CommandShow();
            CommandShowInput showInput = new CommandShowInput();
            commandReturnMessage = commandHelp.Execute(showInput);
            return commandReturnMessage;

        }
    }
}
