using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    class CommandExecute : ICommand
    {
        CommandFactoryImp CommandFactoryImp = new CommandFactoryImp();
        public void Add(string commandLine)
        {
            CommandFactoryImp.GetCommandAdd(commandLine).Execute();
        }
        public void Check(string commandLine)
        {
            CommandFactoryImp.GetCommandCheck(commandLine).Execute();
        }
        public void Uncheck(string commandLine)
        {
            CommandFactoryImp.GetCommandUncheck(commandLine).Execute();
        }
        public void Help()
        {
            CommandFactoryImp.GetCommandHelp().Execute();
        }
        public void Error(string command)
        {
            CommandFactoryImp.GetCommandError(command).Execute();
        }
        public void Show(string commandLine)
        {
            CommandFactoryImp.GetCommandView(commandLine).Execute();
        }
    }
}
