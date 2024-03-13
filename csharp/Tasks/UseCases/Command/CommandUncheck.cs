using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Command
{
    class CommandUncheck : CommandBase
    {
        private string commandRest = string.Empty;
        public CommandUncheck(string cmdL)
        {
            commandRest = cmdL;
        }

        public override void RealExecute()
        {
            Uncheck();
        }
        private void Uncheck()
        {
            int iD = Convert.ToInt32(commandRest);
            SetDone(iD, false);
        }

    }
}
