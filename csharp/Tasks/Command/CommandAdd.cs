using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Command
{
    public class CommandAdd : CommandBase
    {
        private string commandLine = string.Empty;
        public CommandAdd(string cmdL)
        {
            commandLine = cmdL;
        }
        public override void Execute()
        {
            Add();
        }
        private void Add()
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
                projectTasks.Add(new Task { Id = ID, Description = description, Done = false, Date = DateTime.Now, DeadLine = DateTime.Now });
            }
            else
            {
                console.WriteLine("This ID '{0}' is already exist in the Tasks.", ID);
                return;
            }
        }

    }
}
