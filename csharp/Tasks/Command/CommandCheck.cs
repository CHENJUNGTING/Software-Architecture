using System;
using System.Collections.Generic;
using System.Text;
using Tasks.TaskData;

namespace Tasks.Command
{
    class CommandCheck : CommandReturnBase
    {
        private string commandLine = string.Empty;
        public CommandCheck(string cmdL)
        {
            commandLine = cmdL;
        }
        public override void RealExecute()
        {
            Check();
        }
        private void Check()
        {
            SetDone(commandLine, true);
        }

    }
}
