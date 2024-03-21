using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class AddProjectController : CommandController
    {
        public CommandReturnMessage execute(string ExecuteCommand)
        {
            string[] tokens = ExecuteCommand.Split(" ", 3);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandAddProject commandAddProject = new CommandAddProject();
            AddProjectInput addProjectInput = new AddProjectInput();
            addProjectInput.SetProjectName(tokens[2]);
            commandReturnMessage = commandAddProject.Execute(addProjectInput);
            return commandReturnMessage;
        }
    }
}
