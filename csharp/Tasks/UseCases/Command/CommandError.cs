using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandError : CommandBase<CommandErrorInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(CommandErrorInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            string command = commandInput.GetCommand();
            commandReturnMessage.AddMessage($"I don't know what the command \"{command}\" is.");
            return commandReturnMessage;
        }
        public override string GetHelpString()
        {
            return string.Empty;
        }
    }
}
