using System;
using TeamBuilder.App.Core;

namespace TeamBuilder.App
{
    class Application
    {
        static void Main(string[] args)
        {
            new Engine(new CommandDispatcher()).Run();
            Console.WriteLine("Hello World!");
        }
    }
}
