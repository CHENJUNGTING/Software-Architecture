using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks.Entity;
using Tasks.IO;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public abstract class CommandBase<I, O> : ICommand<I, O>
    {
        public abstract O Execute(I commandInput);
        public abstract string GetHelpString();
    }

}

