using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandHelp : CommandBase<CommandHelpInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(CommandHelpInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            commandReturnMessage.AddMessage("Commands:");
            commandReturnMessage.AddMessage("  show");
            commandReturnMessage.AddMessage("  add project <project name>");
            commandReturnMessage.AddMessage("  add task <project name> <task description>");
            commandReturnMessage.AddMessage("  check <task ID>");
            commandReturnMessage.AddMessage("  uncheck <task ID>");
            commandReturnMessage.AddMessage();
            return commandReturnMessage;
        }
    }
}
