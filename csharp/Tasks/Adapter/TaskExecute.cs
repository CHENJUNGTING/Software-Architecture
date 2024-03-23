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
        public CommandReturnMessage Execute(string commandLine)
        {
            string[] tokens = commandLine.Split(" ", 2);
            string feature = tokens[0];
            switch (feature)
            {
                case "add":
                    return FindAddController(commandLine).execute(commandLine);
                case "check":
                    CheckController checkController = new CheckController();
                    return checkController.execute(commandLine);
                case "uncheck":
                    UncheckController uncheckController = new UncheckController();
                    return uncheckController.execute(commandLine);
                case "show":
                    ShowController showController = new ShowController();
                    return showController.execute(commandLine);
                case "help":
                    HelpController helpController = new HelpController();
                    return helpController.execute(commandLine);
                default:
                    ErrorCommandController errorController = new ErrorCommandController();
                    return errorController.execute(commandLine); 
            }
        }

        private static CommandController FindAddController(string consoleCommand)
        {
            string[] tokens = consoleCommand.Split(" ", 3);

            if (tokens.Length < 2)
            {
                ErrorCommandController errorController = new ErrorCommandController();
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
                ErrorCommandController errorController = new ErrorCommandController();
                return errorController;
            }
        }

    }
}
