using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Tasks.UseCases.Message;

namespace Tasks.Entity
{
    public class TaskList
    {
        private static TaskList taskList = null;
        private int ID = 1;

        private IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        public IDictionary<string, IList<Task>> GetTasks()
        {
            return tasks;
        }
        private TaskList() { }
        public static TaskList getTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }

        public void addTask(string project,string description)
        {
            if (tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                projectTasks.Add(new Task { Id = ID, Description = description, Done = false });
            }
        }

        public Task GetTaskById(int id)
        {
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }

        public IList<Task> GetTasksByProjectName(String projectName)
        {
            return tasks[projectName];
        }


        public void AddProject(string projectName)
        {
            tasks[projectName] = new List<Task>();
        }
        public void AddTask(string projectName, string description)
        {
            IList<Task> project = GetTasksByProjectName(projectName);
            int TaskID = NextID();
            project.Add(new Task { Id = TaskID, Description = description, Done = false });
        }
        public void SetDone(int id, bool done)
        {
            Task task = GetTaskById(id);
            task.Done = done;
        }


        public int NextID()
        {
            return ID++;
        }

    }
}
