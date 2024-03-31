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
        private readonly List<Project> _projects = new List<Project>();
        private static int lastTaskId = 1;

        private TaskList() {
        }

        public static TaskList GetTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }

        public List<Task> GetTasksByProjectName(ProjectName projectName)
        {
            return _projects
                    .Where(project => project.GetName() == projectName)
                    .SelectMany(project => project.GetTasks()
                    .Select(task => new ReadOnlyTask(task.GetId(), task.GetDescription(), task.IsDone()) as Task))
                    .ToList();
        }

        public List<Project> GetProjects()
        {
            return _projects.Select(project => new ReadOnlyProject(project.GetName(), project.GetTasks()) as Project).ToList();
        }

        private Project GetProjectByProjectName(ProjectName projectName)
        {
            var project = _projects.FirstOrDefault(project => project.GetName() == projectName);
            if (project != null)
            {
                return new ReadOnlyProject(project.GetName(), project.GetTasks());
            }
            return null;
        }

        public Task GetTaskById(TaskId id)
        {

            var identifiedTask = _projects
                .Select(project => project.GetTasks().FirstOrDefault(task => task.GetId() == id))
                .Where(task => task != null)
                .FirstOrDefault();

            if(identifiedTask != null)
                return new ReadOnlyTask(identifiedTask.GetId(), identifiedTask.GetDescription(), identifiedTask.IsDone());
            return null;
        }

        public void AddProject(ProjectName name)
        {
            Project project = new Project(name, new List<Task>());
            _projects.Add(project);

        }

        public void AddTask(ProjectName projectName, string description, bool done)
        {
            GetProjectByProjectName(projectName).AddTask(TaskId.Of(NextTaskId()),description,done);
        }

        public void SetDone(TaskId id, bool done)
        {
            Task task = _projects
                .Select(project => project.GetTasks().FirstOrDefault(task => task.GetId() == id))
                .Where(task => task != null)
                .FirstOrDefault();

            task.SetDone(done);
        }
        private int NextTaskId()
        {
            return lastTaskId++;
        }
        
        public TaskId GetTaskId()
        {
            return TaskId.Of(lastTaskId);
        }
    }
}
