using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public class CommandAddTask : CommandBase<CommandAddTaskInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(CommandAddTaskInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            TaskList taskList = TaskList.getTaskList();
            ProjectName projectName = commandInput.GetProjectName();
            string description = commandInput.GetDescription();
            IList<Project> projects = taskList.GetTasks();
            int ID = taskList.GetID();

            if (taskList.GetTasksByProjectName(projectName) == null)
            {
                commandReturnMessage.AddMessage($"Could not find a project with the name \"{projectName}\".");
                return commandReturnMessage;
            }
            if (taskList.GetTaskById(ID) == null)
            {
                taskList.AddTask(projectName, description);
            }
            else
            {
                commandReturnMessage.AddMessage($"This ID '{ID}' is already exist in the Tasks.");
                return commandReturnMessage;
            }

            return commandReturnMessage;
        }
    }
}
