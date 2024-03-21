using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class ErrorCommandController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandError commandError = new CommandError();
            ErrorInput errorInput = new ErrorInput();
            commandReturnMessage = commandError.Execute(errorInput);
            return commandReturnMessage;
        }
    }
}
