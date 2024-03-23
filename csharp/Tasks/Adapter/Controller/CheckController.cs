using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class CheckController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            string[] tokens = ExecuteCommand.Split(" ", 2);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandCheck commandCheck = new CommandCheck();
            CommandCheckTaskInput checkTaskInput = new CommandCheckTaskInput();
            checkTaskInput.SetID(Convert.ToInt32(tokens[1]));
            commandReturnMessage = commandCheck.Execute(checkTaskInput);
            return commandReturnMessage;
        }
    }
}
