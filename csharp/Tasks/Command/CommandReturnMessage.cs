using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Command
{
    public class CommandReturnMessage
    {
        private List<string> message = new List<string>();
        public void AddMessage(string message)
        {
            this.message.Add(message);
        }
        public void AddMessage()
        {
            this.message.Add("");
        }
        public List<string> GetMessage() { return message; }

    }
}
