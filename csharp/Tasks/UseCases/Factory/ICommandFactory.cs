using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Factory
{
    public interface ICommandFactory<I, O>  where I : ICommandInput where O : CommandReturnMessage
    {
        ICommand<I, O> GetCommand<Input, Ouput>(string commandLine);
    }
}
