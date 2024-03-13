using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.MyConsole;
namespace Tasks.UseCases.Command
{
    public class CommandAdd : CommandBase
    {
        private string commandRest = string.Empty;
        public CommandAdd(string cmdL)
        {
            commandRest = cmdL;
        }
        public override void RealExecute()
        {
            Add();
        }
        private void Add()
        {
            
            var subcommandRest = commandRest.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            if (subcommand == "project")
            {
                AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                AddTask(projectTask[0], projectTask[1]);
            }
        }
        private void AddProject(string name)
        {
            tasks[name] = new List<Task>();
        }
        private void AddTask(string project, string description)
        {
            int ID = NextID();
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                commandReturnMessage.AddMessage($"Could not find a project with the name \"{project}\".");
                return;
            }


            if (GetTaskById(ID) == null)
            {
                projectTasks.Add(new Task { Id = ID, Description = description, Done = false, Date = DateTime.Now, DeadLine = DateTime.Now });
            }
            else
            {
                commandReturnMessage.AddMessage($"This ID '{ID}' is already exist in the Tasks.");
                return;
            }
        }

    }
}
