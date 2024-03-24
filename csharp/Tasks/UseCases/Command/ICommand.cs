using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
        public interface ICommand<I, O> where I : ICommandInput where O : ICommandReturnMessage
        {
           O Execute(I commandInput);
        }
}
