using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tasks.UseCases.Input
{
    public class AddProjectInput : BaseInput
    {
        private string projectName;

        public string GetProjectName()
        {
            return projectName;
        }
        public void SetProjectName(string projectName)
        {
            this.projectName = projectName;
        }
    }
}
