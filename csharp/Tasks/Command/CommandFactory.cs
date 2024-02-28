using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    interface CommandFactory
    {
        CommandAdd GetCommandAdd(string commandLine);
        CommandCheck GetCommandCheck(string commandLine);
        CommandUncheck GetCommandUncheck(string commandLine);
        CommandError GetCommandError(string commandLine);
        CommandHelp GetCommandHelp();
        CommandView GetCommandView(string commandLine);
    }
}
