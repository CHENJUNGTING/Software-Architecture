using System;
using System.Collections.Generic;
using System.Text;
using Tasks.MyConsole;

namespace Tasks.Command
{
    class CommandExecute : ICommandExecute
    {
        ICommandFactory CommandFactoryImp = new CommandFactory();
        public CommandReturnMessage Add(string commandLine)
        {
            return CommandFactoryImp.GetCommand(CommandList.Add, commandLine).Execute();
        }
        public CommandReturnMessage Check(string commandLine)
        {
            return CommandFactoryImp.GetCommand(CommandList.Check, commandLine).Execute();
        }
        public CommandReturnMessage Uncheck(string commandLine)
        {
            return CommandFactoryImp.GetCommand(CommandList.UnCheck,commandLine).Execute();
        }
        public CommandReturnMessage Help()
        {
            return CommandFactoryImp.GetCommand(CommandList.Help).Execute();
        }
        public CommandReturnMessage Error(string commandLine)
        {
            return CommandFactoryImp.GetCommand(CommandList.Error, commandLine).Execute();
        }
        public CommandReturnMessage Show(string commandLine)
        {
            return CommandFactoryImp.GetCommand(CommandList.View,commandLine).Execute();
        }
    }
}
