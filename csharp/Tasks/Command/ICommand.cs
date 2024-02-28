using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    public interface ICommand
    {
        void Add(string commandLine);
        void Check(string commandLine);
        void Uncheck(string commandLine);
        void Help();
        void Error(string commandLine);
        void Show(string commandLine);
    }
}
