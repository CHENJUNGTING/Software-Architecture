using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tasks.Command
{
    class CommandFactory : ICommandFactory
    {
        public CommandReturnBase GetCommand(CommandList commandType, string commandLine = default)
        {
            
            switch (commandType)
            {
                case CommandList.Add:
                    return new CommandAdd(commandLine);
                case CommandList.Check:
                    return new CommandCheck(commandLine);
                case CommandList.UnCheck:
                    return new CommandUncheck(commandLine);
                case CommandList.Error:
                    return new CommandError(commandLine);
                case CommandList.Help:
                    return new CommandHelp();
                case CommandList.View:
                    return new CommandView(commandLine);
            }
            return null;
        }
    }
}
