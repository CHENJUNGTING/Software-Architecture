using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    class CommandFactory : ICommandFactory
    {
        public CommandBase GetCommandAdd(string commandLine)
        {
            return new CommandAdd(commandLine);
        }
        public CommandBase GetCommandCheck(string commandLine)
        {
            return new CommandCheck(commandLine);
        }
        public CommandBase GetCommandUncheck(string commandLine)
        {
            return new CommandUncheck(commandLine);
        }
        public CommandBase GetCommandError(string commandLine)
        {
           return new CommandError(commandLine);
        }
        public CommandBase GetCommandHelp()
        {
            return new CommandHelp();
        }
        public CommandBase GetCommandView(string commandLine)
        {
            return new CommandView(commandLine);
        }
    }
}
