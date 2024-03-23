using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class CheckController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            string[] tokens = executeCommand.Split(" ", 2);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandCheck commandCheck = new CommandCheck();
            CommandCheckTaskInput checkTaskInput = new CommandCheckTaskInput();
            checkTaskInput.SetID(Convert.ToInt32(tokens[1]));
            commandReturnMessage = commandCheck.Execute(checkTaskInput);
            return commandReturnMessage;
        }
    }
}
