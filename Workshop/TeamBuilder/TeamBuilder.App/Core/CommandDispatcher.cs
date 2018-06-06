using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.App.Commands;

namespace TeamBuilder.App.Core
{
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;

            string[] inputArguments = new string[inputArgs.Length-1];

            if(inputArguments.Length > 1)
            {
                for (int i = 1; i <= inputArgs.Length; i++)
                {
                    inputArguments[i] = inputArgs[i];
                }
            }

            switch (commandName)
            {
                case "Exit":
                    new ExitCommand().Execute(inputArguments);
                    break;

                default:
                    throw new NotSupportedException($"Command Name {commandName} not supported!");
            }

            return result;
        }
    }
}
