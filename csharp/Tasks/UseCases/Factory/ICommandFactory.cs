using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;

namespace Tasks.UseCases.Factory
{
    interface ICommandFactory
    {
        CommandBase GetCommand(string commandLine);
    }
}
