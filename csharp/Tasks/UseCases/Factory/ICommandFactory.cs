using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Factory
{
    interface ICommandFactory
    {
        CommandBase<ICommandInput, CommandReturnMessage> GetCommand<T, ICommandInput, CommandReturnMessage>(string commandLine);
    }
}
