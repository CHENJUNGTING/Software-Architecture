using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    interface ICommandFactory
    {
        CommandReturnBase GetCommand(CommandList commandType, string commandLine = default);
    }
}
