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
            TaskList taskList = TaskList.GetTaskList();
            ProjectName projectName = commandInput.GetProjectName();
            string description = commandInput.GetDescription();
            TaskId ID = taskList.GetTaskId();

            if (taskList.GetTasksByProjectName(projectName) == null)
            {
                commandReturnMessage.AddMessage($"Could not find a project with the name \"{projectName}\".");
                return commandReturnMessage;
            }
            if (taskList.GetTaskById(ID) == null)
            {
                taskList.AddTask(projectName, description, false);
            }
            else
            {
                commandReturnMessage.AddMessage($"This ID '{ID}' is already exist in the Tasks.");
                return commandReturnMessage;
            }

            return commandReturnMessage;
        }
        public override string GetHelpString()
        {
            return "  add task <project name> <task description>";
        }
    }
}
