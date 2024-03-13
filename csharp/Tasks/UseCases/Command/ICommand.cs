using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public interface ICommand
    {
        CommandReturnMessage Execute();
    }
}
