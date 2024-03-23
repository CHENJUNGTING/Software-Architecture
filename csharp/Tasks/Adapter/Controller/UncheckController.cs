using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class UncheckController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            string[] tokens = executeCommand.Split(" ", 2);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandUncheck commandUncheck = new CommandUncheck();
            CommandUncheckTaskInput uncheckTaskInput = new CommandUncheckTaskInput();
            uncheckTaskInput.SetID(Convert.ToInt32(tokens[1]));
            commandReturnMessage = commandUncheck.Execute(uncheckTaskInput);
            return commandReturnMessage;
        }
    }
}
