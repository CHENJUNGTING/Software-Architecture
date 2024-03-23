using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class AddTaskController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            string[] tokens = ExecuteCommand.Split(" ", 4);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandAddTask commandAddTask = new CommandAddTask();
            CommandAddTaskInput addTaskInput = new CommandAddTaskInput();
            ProjectName projectName = new ProjectName(tokens[2]);
            addTaskInput.SetProjectName(projectName);
            addTaskInput.SetDescription(tokens[3]);
            commandReturnMessage = commandAddTask.Execute(addTaskInput);
            return commandReturnMessage;
        }
    }
}
