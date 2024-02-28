using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
     class CommandUncheck : CommandBase
    {
        private string commandLine = string.Empty;
        public CommandUncheck(string cmdL)
        {
            commandLine = cmdL;
        }

        public override void Execute()
        {
            Uncheck();
        }
        private void Uncheck()
        {
            SetDone(commandLine, false);
        }

    }
}
