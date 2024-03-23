using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class ErrorController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandError commandError = new CommandError();
            CommandErrorInput errorInput = new CommandErrorInput();
            commandReturnMessage = commandError.Execute(errorInput);
            return commandReturnMessage;
        }
    }
}
