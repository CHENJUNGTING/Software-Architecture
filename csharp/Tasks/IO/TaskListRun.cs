
using System.Collections.Generic;
using Tasks.UseCases.Command;
using Tasks.Adapter;
using Tasks.UseCases.Message;

namespace Tasks.IO
{
    public sealed class TaskListRun
    {
        private const string QUIT = "quit";

        public static IConsole console { get; private set; }

        public static void Main(string[] args)
        {
            new TaskListRun(new RealConsole()).Run();
        }

        public TaskListRun(IConsole Pconsole)
        {
            console = Pconsole;
        }

        public void Run()
        {
            ITaskExecute taskExecute = new TaskExecute();
            ICommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            while (true)
            {
                console.Write("> ");
                var command = console.ReadLine();
                if (command == QUIT)
                {
                    break;
                }
                commandReturnMessage = taskExecute.ExecuteTask(command);
                ShowOutputMessage(commandReturnMessage.GetMessage());
            }
        }
        private void ShowOutputMessage(List<string> message)
        {
            if (message.Count > 0)
            {
                foreach (var msg in message)
                {
                    console.WriteLine(msg);
                }
            }
        }
    }
}
