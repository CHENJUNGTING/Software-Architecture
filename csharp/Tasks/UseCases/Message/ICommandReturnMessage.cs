using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCases.Message
{
    public interface ICommandReturnMessage
    {
        List<string> GetMessage();
    }
}
