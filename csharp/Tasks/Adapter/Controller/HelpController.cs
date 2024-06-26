﻿using System;
using System.Collections.Generic;
using System.Text;
using Tasks.UseCases.Command;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.Adapter.Controller
{
    public class HelpController : ICommandController
    {
        public CommandReturnMessage Execute(string executeCommand)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            CommandHelp commandHelp = new CommandHelp();
            CommandHelpInput showInput = new CommandHelpInput();
            commandReturnMessage = commandHelp.Execute(showInput);
            return commandReturnMessage;

        }
    }
}
