using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Command;

namespace Tasks.Execute
{
    internal class TaskExecute : ITaskExecute
    {

        private readonly ICommandExecute cmd = new CommandExecute();
        private CommandReturnMessage message = new CommandReturnMessage();
        public List<string> Execute(string commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var command = commandRest[0];
            
            switch (command)
            {
                case "show":
                    //cmd.show(commandRest[1]);
                    message = cmd.Show("");
                    break;
                case "add":
                    message = cmd.Add(commandRest[1]);
                    break;
                case "check":
                    message = cmd.Check(commandRest[1]);
                    break;
                case "uncheck":
                    message = cmd.Uncheck(commandRest[1]);
                    break;
                case "help":
                    message = cmd.Help();
                    break;
                default:
                    message = cmd.Error(command);
                    break;
            }

            return message.GetMessage();
        }
    }
}
