using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class ProjectName
    {
        private string projectName;

        public ProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public override string ToString()
        {
            return projectName;
        }
        public static bool operator ==(ProjectName ProjectName_1, ProjectName ProjectName_2)
        {
            return ProjectName_1.ToString() == ProjectName_2.ToString();
        }
        public static bool operator !=(ProjectName ProjectName_1, ProjectName ProjectName_2)
        {
            return ProjectName_1.ToString() != ProjectName_2.ToString();
        }
    }
}
