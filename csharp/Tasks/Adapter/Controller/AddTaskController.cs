using System;
using System.Collections.Generic;
using System.Text;
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
            AddTaskInput addTaskInput = new AddTaskInput();
            addTaskInput.SetProjectName(tokens[2]);
            addTaskInput.SetDescription(tokens[3]);
            commandReturnMessage = commandAddTask.Execute(addTaskInput);
            return commandReturnMessage;
        }
    }
}
