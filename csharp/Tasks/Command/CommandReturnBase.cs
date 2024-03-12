using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Tasks.MyConsole;
using Tasks.TaskData;
namespace Tasks.Command
{
    public abstract class CommandReturnBase : ICommandReturn
    {
        private static TaskListData taskListData = new TaskListData();
        protected CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
        protected static IDictionary<string, IList<Task>> tasks = taskListData.GetTasks();
        public abstract void RealExecute();
        public CommandReturnMessage Execute()
        {
            RealExecute();
            return commandReturnMessage;
        }
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
                commandReturnMessage.AddMessage($"Could not find a task with an ID of {id}.");
                return;
            }

            identifiedTask.Done = done;
        }
    }
}
