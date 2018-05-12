namespace BillsPaymentSystem.Data
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=.\SQLEXPRESS;Database=BillsPaymentSystemDb;Integrated Security=True;";
    }
}