using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Command
{
    public class CommandView : CommandBase
    {
        private string commandLine = string.Empty;
        public override void Execute()
        {
            ViewByProject();
        }
        public CommandView(string cmdL)
        {
            commandLine = cmdL;
        }
        /*
        public List<Task> unPackTasks()
        {
            var sortedTasks = new List<Task>();
            foreach (var project in tasks)
            {
                foreach (var task in project.Value)
                {
                    sortedTasks.Add(task);

                }
            }
            return sortedTasks;
        }
        public void ConsoleWriteTasks(List<Task> _tasks)
        {
            foreach (var task in _tasks)
            {
                console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
            }
        }
        public void ViewByDate()
        {
            var sortedTasks = unPackTasks();
            sortedTasks = sortedTasks.OrderBy(t => t.Date).ToList();
            ConsoleWriteTasks(sortedTasks);
        }
        public void ViewByDeadline()
        {
            var sortedTasks = unPackTasks();
            sortedTasks = sortedTasks.OrderBy(t => t.Date).ToList();
            ConsoleWriteTasks(sortedTasks);
        }
        */
        private void ViewByProject()
        {
            foreach (var project in tasks)
            {
                console.WriteLine(project.Key);
                foreach (var task in project.Value)
                {
                    // console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
                    console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
                }
                console.WriteLine();
            }
        }
    }
}
