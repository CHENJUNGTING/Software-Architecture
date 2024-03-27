using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class AddTaskController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            string[] tokens = executeCommand.Split(" ", 4);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandAddTask commandAddTask = new CommandAddTask();
            CommandAddTaskInput addTaskInput = new CommandAddTaskInput();
            string projectName = tokens[2];
            addTaskInput.SetProjectName(projectName);
            addTaskInput.SetDescription(tokens[3]);
            commandReturnMessage = commandAddTask.Execute(addTaskInput);
            return commandReturnMessage;
        }
    }
}
