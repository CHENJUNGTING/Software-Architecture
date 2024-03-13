using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Command
{
    class CommandCheck : CommandBase
    {
        private string commandRest = string.Empty;
        public CommandCheck(string cmdL)
        {
            commandRest = cmdL;
        }
        public override void RealExecute()
        {
            Check();
        }
        private void Check()
        {
            int iD = Convert.ToInt32(commandRest);
            SetDone(iD, true);
        }

    }
}
