using System.Data.Common;

namespace FootballBetting.Data
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=DESKTOP-5FMQC2G\SQLEXPRESS;Database=Hospital;Integrated Security=True;";
    }
}