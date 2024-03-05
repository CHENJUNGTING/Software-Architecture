
using System.Collections.Generic;
using Tasks.Command;
using Tasks.MyConsole;
using Tasks.TaskData;

namespace Tasks
{
    public sealed class TaskList
    {
        private const string QUIT = "quit";

        private static readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        private readonly CommandExecute cmd = new CommandExecute();
        public static IConsole console { get; private set; }

        public static IDictionary<string, IList<Task>> GetTasks()
        {
            return tasks;
        }
        public static IConsole GetConsole()
        {
            return console;
        }
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
            while (true)
            {
                console.Write("> ");
                var command = console.ReadLine();
                if (command == QUIT)
                {
                    break;
                }
                Execute(command);
            }
        }

        private void Execute(string commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var command = commandRest[0];
            switch (command)
            {
                case "show":
                    //cmd.show(commandRest[1]);
                    cmd.Show("");
                    break;
                case "add":
                    cmd.Add(commandRest[1]);
                    break;
                case "check":
                    cmd.Check(commandRest[1]);
                    break;
                case "uncheck":
                    cmd.Uncheck(commandRest[1]);
                    break;
                case "help":
                    cmd.Help();
                    break;
                default:
                    cmd.Error(command);
                    break;
            }
        }
        /*
       public void Delete(string taskId)
       {
           foreach (var taskList in tasks.Values)
           {
               var taskToRemove = taskList.FirstOrDefault(task => task.Id == taskId);

               if (taskToRemove != null)
               {
                   taskList.Remove(taskToRemove);
                   return;
               }
           }
           Console.WriteLine($"Task with ID {taskId} not found.");
       }

       private void Show(string commandLine)
       {
           if(commandLine == "by date")
           {
               var sortedTasks = new List<Task>();
               foreach (var project in tasks)
               {
                   foreach (var task in project.Value)
                   {
                       sortedTasks.Add(task);

                   }
               }
               sortedTasks = sortedTasks.OrderBy(t => t.Date).ToList();
               foreach(var task in sortedTasks)
               {
                   console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
               }
           }
           else if(commandLine == "by deadline")
           {
               var sortedTasks = new List<Task>();
               foreach (var project in tasks)
               {
                   foreach (var task in project.Value)
                   {
                       sortedTasks.Add(task);
                   }
               }
               sortedTasks = sortedTasks.OrderBy(t => t.DeadLine).ToList();
               foreach (var task in sortedTasks)
               {
                   console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
               }
           }
           else if(commandLine == "by project")
           {
               foreach (var project in tasks)
               {
                   console.WriteLine(project.Key);
                   foreach (var task in project.Value)
                   {
                       console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
                   }
                   console.WriteLine();
               }
           }

       }

       private void Today()
       {
           foreach (var project in tasks)
           { 
               foreach (var task in project.Value)
               {
                   if(task.DeadLine.Date == DateTime.Today)
                       console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
               }
               console.WriteLine();
           }
       }
       private void Add(string commandLine)
       {
           var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
           var subcommand = subcommandRest[0];
           if (subcommand == "project")
           {
               AddProject(subcommandRest[1]);
           }
           else if (subcommand == "task")
           {
               var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 3);
               AddTask(projectTask[0], projectTask[1], projectTask[2]);
           }
       }




       private void AddProject(string name)
       {
           tasks[name] = new List<Task>();
       }
       private void AddTask(string ID, string project, string description)
       {
           if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
           {
               Console.WriteLine("Could not find a project with the name \"{0}\".", project);
               return;
           }

           if (int.TryParse(ID, out _))
           {
               Console.WriteLine("Could not using special characters from the ID. \"{0}\".", ID);
               return;
           }
           if (GetTaskById(ID) == null)
           {
               projectTasks.Add(new Task { Id = ID, Description = description, Done = false,Date = DateTime.Now, DeadLine = DateTime.Now });
           }
           else
           {
               console.WriteLine("This ID '{0}' is already exist in the Tasks.", ID);
               return;
           }
       }

       private void Check(string idString)
       {
           SetDone(idString, true);
       }

       private void Uncheck(string idString)
       {
           SetDone(idString, false);
       }

       private void SetDeadline(string commandLine)
       {
           var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
           string id = subcommandRest[0];
           var identifiedTask = GetTaskById(id);
           if (identifiedTask != null)
           {
               identifiedTask.DeadLine = DateTime.ParseExact(subcommandRest[1], "yyyyMMdd", null);
           }
           else
           {
               console.WriteLine("Could not find a task with an ID of {0}.", id);
               return;
           }
       }
       private Task GetTaskById(string id)
       {
           var identifiedTask = tasks
               .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
               .Where(task => task != null)
               .FirstOrDefault();

           return identifiedTask;
       }

       private void SetDone(string id, bool done)
       {
           var identifiedTask = GetTaskById(id);

           if (identifiedTask == null)
           {
               console.WriteLine("Could not find a task with an ID of {0}.", id);
               return;
           }

           identifiedTask.Done = done;
       }

       private void Help()
       {
           console.WriteLine("Commands:");
           console.WriteLine("  show");
           console.WriteLine("  add project <project name>");
           console.WriteLine("  add task <project name> <task description>");
           console.WriteLine("  check <task ID>");
           console.WriteLine("  uncheck <task ID>");
           console.WriteLine();
       }

       private void Error(string command)
       {
           console.WriteLine("I don't know what the command \"{0}\" is.", command);
       }
       */
    }
}
