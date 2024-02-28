using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    class CommandCheck : CommandBase
    {
        private string commandLine = string.Empty;
        public CommandCheck(string cmdL)
        {
            commandLine = cmdL;
        }
        public override void Execute() {
            Check();
        }
        private void Check()
        {
            SetDone(commandLine, true);
        }

    }
}
