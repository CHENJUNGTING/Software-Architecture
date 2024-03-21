using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class UncheckController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            string[] tokens = ExecuteCommand.Split(" ", 2);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandUncheck commandUncheck = new CommandUncheck();
            UncheckTaskInput uncheckTaskInput = new UncheckTaskInput();
            uncheckTaskInput.SetID(Convert.ToInt32(tokens[1]));
            commandReturnMessage = commandUncheck.Execute(uncheckTaskInput);
            return commandReturnMessage;
        }
    }
}
