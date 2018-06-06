

using System;

namespace TeamBuilder.App.Commands
{
    public class ExitCommand
    {
        public string Execute(string[] inputArgs)
        {
            if(inputArgs.Length == 0)
            {
                Environment.Exit(0);                
            }

            return "Bye";
        }
    }
}
