using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks.Entity;
using Tasks.UseCases.Message;

namespace Tasks.Entity
{
    public class TaskList
    {
        private static TaskList taskList = null;
        private int ID = 1;
        private readonly List<Project> _projects = new List<Project>();

        private TaskList() { }

        private List<Task> GetTasksByProjectNameInternal(ProjectName projectName)
        {
            foreach (Project project in _projects)
            {
                if (project.GetName() == projectName)
                {
                    return project.GetTasks();
                }
            }
            return null;
        }

        public ReadOnlyCollection<Task> GetTasksByProjectName(ProjectName projectName)
        {
            var tasks = GetTasksByProjectNameInternal(projectName).AsReadOnly();
            return tasks;
        }

        public static TaskList GetTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }

        public ReadOnlyCollection<Project> GetProjects()
        {
            return _projects.AsReadOnly();
        }

        public int GetID()
        {
            return ID;
        }

        public Task GetTaskById(int id)
        {

            var identifiedTask = _projects
                .Select(project => project.GetTasks().FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }

        public void AddProject(ProjectName name)
        {
            Project project = new Project(name, new List<Task>());
            _projects.Add(project);

        }

        public void AddTask(ProjectName projectName, string description)
        {
            IList<Task> project = GetTasksByProjectNameInternal(projectName);
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
