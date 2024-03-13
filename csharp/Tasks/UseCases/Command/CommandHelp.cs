using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Command
{
    class CommandHelp : CommandBase
    {
        public override void RealExecute()
        {
            Help();
        }
        private void Help()
        {
            commandReturnMessage.AddMessage("Commands:");
            commandReturnMessage.AddMessage("  show");
            commandReturnMessage.AddMessage("  add project <project name>");
            commandReturnMessage.AddMessage("  add task <project name> <task description>");
            commandReturnMessage.AddMessage("  check <task ID>");
            commandReturnMessage.AddMessage("  uncheck <task ID>");
            commandReturnMessage.AddMessage();

        }
    }
}
