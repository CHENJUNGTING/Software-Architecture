using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class AddProjectController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            string[] tokens = executeCommand.Split(" ", 3);
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandAddProject commandAddProject = new CommandAddProject();
            CommandAddProjectInput addProjectInput = new CommandAddProjectInput();
            string projectName = tokens[2];
            addProjectInput.SetProjectName(projectName);
            commandReturnMessage = commandAddProject.Execute(addProjectInput);
            return commandReturnMessage;
        }
    }
}
