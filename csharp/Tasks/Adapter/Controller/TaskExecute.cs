using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Factory;
using Tasks.UseCases.Command;
using Tasks.UseCases.Message;

namespace Tasks.Controller
{
    internal class TaskExecute : ITaskExecute
    {

        private readonly ICommandFactory Command = new CommandFactory();
        private CommandReturnMessage message = new CommandReturnMessage();
        public List<string> Execute(string commandLine)
        {
            ICommand commandbase =  Command.GetCommand(commandLine);
            message = commandbase.Execute();
            return message.GetMessage();
        }
    }
}
