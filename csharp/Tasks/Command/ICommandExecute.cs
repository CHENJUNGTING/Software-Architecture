using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    public interface ICommandExecute
    {
        CommandReturnMessage Add(string commandLine);
        CommandReturnMessage Check(string commandLine);
        CommandReturnMessage Uncheck(string commandLine);
        CommandReturnMessage Help();
        CommandReturnMessage Error(string commandLine);
        CommandReturnMessage Show(string commandLine);
    }
}
