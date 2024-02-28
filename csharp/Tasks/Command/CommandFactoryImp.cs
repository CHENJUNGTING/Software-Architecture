using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    class CommandFactoryImp : CommandFactory
    {
        public CommandAdd GetCommandAdd(string commandLine)
        {
            return new CommandAdd(commandLine);
        }
        public CommandCheck GetCommandCheck(string commandLine)
        {
            return new CommandCheck(commandLine);
        }
        public CommandUncheck GetCommandUncheck(string commandLine)
        {
            return new CommandUncheck(commandLine);
        }
        public CommandError GetCommandError(string commandLine)
        {
           return new CommandError(commandLine);
        }
        public CommandHelp GetCommandHelp()
        {
            return new CommandHelp();
        }
        public CommandView GetCommandView(string commandLine)
        {
            return new CommandView(commandLine);
        }
    }
}
