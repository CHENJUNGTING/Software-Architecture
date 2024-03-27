using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCases.Input
{
    public class CommandAddTaskInput : ICommandInput
    {
        private ProjectName projectName;
        private string description;
        public ProjectName GetProjectName()
        {
            return projectName;
        }

        public string GetDescription()
        {
            return description;
        }
        public void SetProjectName(string projectName)
        {
            this.projectName = new ProjectName(projectName);
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }

    }
}
