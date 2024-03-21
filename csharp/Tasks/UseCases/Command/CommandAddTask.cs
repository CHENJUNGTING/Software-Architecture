using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public class CommandAddTask : CommandBase<AddTaskInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(AddTaskInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            Entity.TaskList taskList = Entity.TaskList.getTaskList();
            string projectName = commandInput.GetProjectName();
            string description = commandInput.GetDescription();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            int ID = taskList.GetID();
            if (!tasks.TryGetValue(projectName, out IList<Task> projectTasks))
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
