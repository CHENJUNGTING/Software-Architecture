using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCases.Input
{
    public class CommandAddProjectInput : ICommandInput
    {
        private ProjectName projectName;

        public ProjectName GetProjectName()
        {
            return projectName;
        }
        public void SetProjectName(ProjectName projectName)
        {
            this.projectName = projectName;
        }
    }
}
