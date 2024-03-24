using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public class CommandUncheck : CommandBase<CommandUncheckTaskInput, CommandReturnMessage>

    {
        public override CommandReturnMessage Execute(CommandUncheckTaskInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            int iD = commandInput.GetID();
            if (taskList.GetTaskById(iD) == null)
            {
                commandReturnMessage.AddMessage("Check Failed ID Not Find");
                return commandReturnMessage;
            }
            taskList.SetDone(iD, false);
            return commandReturnMessage;
        }
        public override string GetHelpString()
        {
            return "  uncheck <task ID>";
        }

    }
}
