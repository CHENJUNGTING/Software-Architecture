using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandAddProject : CommandBase<AddProjectInput, CommandReturnMessage>

    {

        public override CommandReturnMessage Execute(AddProjectInput commandInput)
        {
            string projectName = commandInput.GetProjectName();
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            TaskList taskList = TaskList.getTaskList();
            taskList.AddProject(projectName);

            if(taskList.GetTasksByProjectName(projectName) == null)
            {
                commandReturnMessage.AddMessage("Failed to Add Project");
            }
            return commandReturnMessage;
        }
    }
}
