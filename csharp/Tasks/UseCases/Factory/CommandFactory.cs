using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Tasks.UseCases.Command;

namespace Tasks.UseCases.Factory
{
    class CommandFactory : ICommandFactory
    {
        public CommandBase GetCommand(string commandLine)
        {
            String[] commandRest = commandLine.Split(" ", 2);
            String command = commandRest[0];
            switch (command)
            {
                case "show":
                    return new CommandView("");
                case "add":
                    return new CommandAdd(commandRest[1]);
                case "check":
                    return new CommandCheck(commandRest[1]);
                case "uncheck":
                    return new CommandUncheck(commandRest[1]);
                case "help":
                    return new CommandHelp();
                default:
                    return new CommandError(command);
            }
        }
    }
}
