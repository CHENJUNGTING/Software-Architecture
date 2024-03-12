using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
     class CommandUncheck : CommandReturnBase
    {
        private string commandLine = string.Empty;
        public CommandUncheck(string cmdL)
        {
            commandLine = cmdL;
        }

        public override void RealExecute()
        {
            Uncheck();
        }
        private void Uncheck()
        {
            SetDone(commandLine, false);
        }

    }
}
