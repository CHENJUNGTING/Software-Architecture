using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandAddProject : CommandBase<CommandAddProjectInput, CommandReturnMessage>

    {

        public override CommandReturnMessage Execute(CommandAddProjectInput commandInput)
        {
            ProjectName projectName = commandInput.GetProjectName();
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            taskList.AddProject(projectName);

            if(taskList.GetTasksByProjectName(projectName) == null)
            {
                commandReturnMessage.AddMessage("Failed to Add Project");
            }
            return commandReturnMessage;
        }

        public override string GetHelpString()
        {
            return "  add project <project name>";
        }
    }
}
