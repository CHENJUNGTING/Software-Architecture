using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Command
{
    interface ICommandReturn
    {
        CommandReturnMessage Execute();
    }
}
