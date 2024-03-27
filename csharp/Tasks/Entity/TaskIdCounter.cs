﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskIdCounter
    {
        private static int id = 1;

        public static int NextID() {  return id++; }

        public static int GetID()
        {
            return id;
        }
    }
}