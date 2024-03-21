using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandUncheck : CommandBase<CheckTaskInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(UncheckTaskInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            TaskList taskList = TaskList.getTaskList();
            int iD = commandInput.GetID();
            if (taskList.GetTaskById(iD) == null)
            {
                commandReturnMessage.AddMessage("Check Failed ID Not Find");
                return commandReturnMessage;
            }
            taskList.SetDone(iD, false);
            return commandReturnMessage;
        }


    }
}
