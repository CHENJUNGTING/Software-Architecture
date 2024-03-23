using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tasks.UseCases.Input;
using Tasks.UseCases.Message;

namespace Tasks.UseCases.Command
{
    class CommandHelp : CommandBase<CommandHelpInput, CommandReturnMessage>
    {
        private bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public override CommandReturnMessage Execute(CommandHelpInput commandInput)
        {
            
            CommandReturnMessage commandReturnMessage = new CommandReturnMessage();
            commandReturnMessage.AddMessage("Command");

            //利用反射獲得所有繼承於CommandBase的子類別
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (IsSubclassOfRawGeneric(typeof(CommandBase<,>), type) && !type.IsAbstract)
                    {
                        var method = type.GetMethod("GetHelpString");
                        object instance = Activator.CreateInstance(type);
                        string helpString = method.Invoke(instance, null).ToString();
                        if(helpString != string.Empty) {
                            commandReturnMessage.AddMessage(helpString);
                        }
                    }
                }
            }

            commandReturnMessage.AddMessage();
            return commandReturnMessage;
        }
        public override string GetHelpString()
        {
            return "  help";
        }
    }
}
