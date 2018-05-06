using System;
using StudentSystem.Data;

namespace StudentSystem.Client
{
    class Startup
    {
        static void Main()
        {
            using (var db = StudentSystemContext.CreateInstance())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
