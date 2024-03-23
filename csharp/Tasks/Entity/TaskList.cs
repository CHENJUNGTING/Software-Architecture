using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks.UseCases.Message;

namespace Tasks.Entity
{

    public struct Test
    {

    }
    public class TaskList
    {
        private static TaskList taskList = null;
        private int ID = 1;

        //private IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        private List<Project> projects = new List<Project>();

        public List<Project> GetTasks()
        {
            return projects;
        }
         public int GetID()
        {
            return ID;
        }
        public static TaskList getTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }

        public void addTask(ProjectName projectName,string description)
        {
            foreach (Project project in projects)
            {
                if (project.getName().Equals(projectName))
                {
                    project.getTasks().Add(new Task { Id = ID, Description = description, Done = false });
                }
            }
        }

        public Task GetTaskById(int id)
        {

            var identifiedTask = projects
                .Select(project => project.getTasks().FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }

        public IList<Task> GetTasksByProjectName(ProjectName projectName)
        {
            foreach (Project project in projects)
            {
                if (project.getName() == projectName)
                {
                    return project.getTasks();
                }
            }
            return null;
        }


        public void AddProject(ProjectName name)
        {
            Project project = new Project(name, new List<Task>());
            this.projects.Add(project);

        }
        public void AddTask(ProjectName projectName, string description)
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
