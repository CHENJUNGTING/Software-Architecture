﻿using System;
using System.Collections.Generic;
using System.Text;
using Tasks.TaskData;

namespace Tasks.Command
{
    class CommandError : CommandReturnBase
    {
        private string commandLine = string.Empty;
        public CommandError(string cmdL)
        {
            commandLine = cmdL;
        }
        public override void RealExecute()
        {
            Error();
        }
        private void Error()
        {
            commandReturnMessage.AddMessage($"I don't know what the command \"{commandLine}\" is.");
        }
    }
}
