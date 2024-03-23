using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Message;
using Tasks.UseCases.Input;
using Tasks.Adapter.Controller;

namespace Tasks.Adapter
{
    internal class TaskExecute : ITaskExecute
    {
        public CommandReturnMessage ExecuteTask(string commandLine)
        {
            string[] tokens = commandLine.Split(" ", 2);
            string feature = tokens[0];
            switch (feature)
            {
                case "add":
                    return FindAddController(commandLine).Execute(commandLine);
                case "check":
                    CheckController checkController = new CheckController();
                    return checkController.Execute(commandLine);
                case "uncheck":
                    UncheckController uncheckController = new UncheckController();
                    return uncheckController.Execute(commandLine);
                case "show":
                    ShowController showController = new ShowController();
                    return showController.Execute(commandLine);
                case "help":
                    HelpController helpController = new HelpController();
                    return helpController.Execute(commandLine);
                default:
                    ErrorController errorController = new ErrorController();
                    return errorController.Execute(commandLine); 
            }
        }

        private static ICommandController FindAddController(string consoleCommand)
        {
            string[] tokens = consoleCommand.Split(" ", 3);

            if (tokens.Length < 2)
            {
                ErrorController errorController = new ErrorController();
                return errorController;
            }

            if (tokens[1] =="project")
            {
                return new AddProjectController();
            }
            else if (tokens[1] == "task")
            {
                return new AddTaskController();
            }
            else
            {
                ErrorController errorController = new ErrorController();
                return errorController;
            }
        }

    }
}
