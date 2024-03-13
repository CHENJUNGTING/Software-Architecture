
using System.Collections.Generic;
using Tasks.UseCases.Command;
using Tasks.Controller;
using Tasks.MyConsole;

namespace Tasks
{
    public sealed class TaskList
    {
        private const string QUIT = "quit";

        public static IConsole console { get; private set; }
        
        public static void Main(string[] args)
        {
            new TaskList(new RealConsole()).Run();
        }

        public TaskList(IConsole Pconsole)
        {
            console = Pconsole;
        }

        public void Run()
        {
            ITaskExecute taskExecute = new TaskExecute();
            List<string> commandReturnMessage = new List<string>();
            while (true)
            {
                console.Write("> ");
                var command = console.ReadLine();
                if (command == QUIT)
                {
                    break;
                }
                commandReturnMessage = taskExecute.Execute(command);
                ShowOutputMessage(commandReturnMessage);
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
