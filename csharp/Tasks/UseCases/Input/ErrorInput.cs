using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Input
{
    class ErrorInput<T> : BaseInput<T>
    {
        private string command;
        public void SetCommand(string command) { this.command = command; }
        public string GetCommand() { return command; }
    }
}
