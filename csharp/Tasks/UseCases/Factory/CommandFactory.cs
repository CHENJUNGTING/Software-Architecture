using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Factory
{
    class CommandFactory<I,O> : ICommandFactory<I, O> where I : ICommandInput where O : CommandReturnMessage
    {
        public ICommand<I,O> GetCommand<Input, Ouput>(string commandLine)
        {
            String[] commandRest = commandLine.Split(" ", 2);
            String command = commandRest[0];
            switch (command)
            {
                case "show":
                    CommandBase<ShowInput, CommandReturnMessage> commandView = new CommandShow();
                    return (ICommand<I, O>)commandView;
                case "add":
                    CommandBase<AddProjectInput, CommandReturnMessage> commandAddProject = new CommandAddProject();
                    return (ICommand<I, O>)commandAddProject;
                case "check":
                    CommandBase<CheckTaskInput, CommandReturnMessage> commandCheck = new CommandCheck();
                    return (ICommand<I, O>)commandCheck;
                case "uncheck":
                    CommandBase<UncheckTaskInput, CommandReturnMessage> commandUncheck = new CommandUncheck();
                    return (ICommand<I, O>)commandUncheck;
                case "help":
                    CommandBase<HelpInput, CommandReturnMessage> commandHelp = new CommandHelp();
                    return (ICommand<I, O>)commandHelp;
                default:
                    CommandBase<ErrorInput, CommandReturnMessage > commandError = new CommandError();
                    return (ICommand<I, O>)commandError;
            }
        }
    }
}
