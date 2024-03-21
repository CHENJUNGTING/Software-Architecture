using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Input
{
    public class ErrorInput : BaseInput
    {
        private string command;
        public void SetCommand(string command) { this.command = command; }
        public string GetCommand() { return command; }
    }
}
