using System;
using FootballBetting.Data;

namespace FootballBetting
{
    class Startup
    {
        static void Main()
        {
            using (var db = new FootballBettingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
