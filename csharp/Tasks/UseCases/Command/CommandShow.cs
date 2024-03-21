using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Entity;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public class CommandShow : CommandBase<ShowInput, CommandReturnMessage>
    {
        public override CommandReturnMessage Execute(ShowInput commandInput)
        {
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            Entity.TaskList taskList = Entity.TaskList.getTaskList();

            foreach (var project in taskList.GetTasks())
            {
                commandReturnMessage.AddMessage(project.Key);
                foreach (var task in project.Value)
                {
                    // console.WriteLine("    [{0}] {1}: {2}: {3}", (task.Done ? 'x' : ' '), task.Id, task.Description, task.DeadLine.ToString("yyyy/MM/dd"));
                    commandReturnMessage.AddMessage($"    [{(task.Done ? 'x' : ' ')}] {task.Id}: {task.Description}");
                }
                commandReturnMessage.AddMessage();
            }

            return commandReturnMessage;
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

    }
}
