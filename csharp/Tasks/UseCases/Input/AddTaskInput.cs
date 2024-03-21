﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Input
{
    class AddTaskInputm<T> : BaseInput<T>
    {
        private string projectName;
        private string description;
        public string GetProjectName()
        {
            return projectName;
        }

        public string GetDescription()
        {
            return description;
        }
        public void SetProjectName(string projectName)
        {
            this.projectName = projectName;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }

    }
}