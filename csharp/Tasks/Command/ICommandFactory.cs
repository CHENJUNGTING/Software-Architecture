using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    interface ICommandFactory
    {
        CommandBase GetCommandAdd(string commandLine);
        CommandBase GetCommandCheck(string commandLine);
        CommandBase GetCommandUncheck(string commandLine);
        CommandBase GetCommandError(string commandLine);
        CommandBase GetCommandHelp();
        CommandBase GetCommandView(string commandLine);
    }
}
