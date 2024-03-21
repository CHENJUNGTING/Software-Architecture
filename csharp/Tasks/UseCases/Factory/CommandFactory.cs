using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Input;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Factory
{
    class CommandFactory : ICommandFactory
    {
        public CommandBase<ICommandInput,CommandReturnMessage> GetCommand(string commandLine)
        {
            String[] commandRest = commandLine.Split(" ", 2);
            String command = commandRest[0];
            switch (command)
            {
                case "show":
                    CommandBase<ViewInput, CommandReturnMessage> commandView = new CommandView();
                    return commandView;
                case "add":
                    return new CommandAddProject();
                case "check":
                    return new CommandCheck();
                case "uncheck":
                    return new CommandUncheck();
                case "help":
                    return new CommandHelp();
                default:
                    return new CommandError();
            }
        }
    }
}
