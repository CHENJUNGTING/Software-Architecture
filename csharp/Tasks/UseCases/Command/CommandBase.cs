using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    public abstract class CommandBase : ICommand
    {
        private static TaskListData taskListData = new TaskListData();
        private static int ID = 1;
        protected CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
        protected static IDictionary<string, IList<Task>> tasks = taskListData.GetTasks();
        
        public abstract void RealExecute();
        //RealExecute is a Template Method.
        public CommandReturnMessage Execute()
        {
            RealExecute();
            return commandReturnMessage;
        }
        protected Task GetTaskById(int id)
        {
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected void SetDone(int id, bool done)
        {
            var identifiedTask = GetTaskById(id);

            if (identifiedTask == null)
            {
                commandReturnMessage.AddMessage($"Could not find a task with an ID of {id}.");
                return;
            }

            identifiedTask.Done = done;
        }
        protected int NextID()
        {
            return ID++;
        }
    }
}
