using System.Collections.Generic;
using System.Linq;
using Tasks.MyConsole;
using Tasks.TaskData;
namespace Tasks.Command
{
    public abstract class CommandBase : ICommand
    {
        public abstract void Execute();
        protected static IDictionary<string, IList<Task>> tasks = TaskList.GetTasks();
        protected static IConsole console = TaskList.GetConsole();
        protected Task GetTaskById(string id)
        {
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected void SetDone(string id, bool done)
        {
            var identifiedTask = GetTaskById(id);

            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", id);
                return;
            }

            identifiedTask.Done = done;
        }
    }
}
