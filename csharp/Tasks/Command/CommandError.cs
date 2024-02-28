using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    class CommandError : CommandBase
    {
        private string commandLine = string.Empty;
        public CommandError(string cmdL)
        {
            commandLine = cmdL;
        }
        public override void Execute()
        {
            Error();
        }
        private void Error()
        {
            console.WriteLine("I don't know what the command \"{0}\" is.", commandLine);
        }
    }
}
