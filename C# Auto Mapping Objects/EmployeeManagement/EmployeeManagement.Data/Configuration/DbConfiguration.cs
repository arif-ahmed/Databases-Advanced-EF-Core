namespace EmployeeManagement.Data.Configuration
{
    internal static class DbConfiguration
    {
        public static string ConnectionString { get; set; } = @"Server=.\SQLEXPRESS;Database=EmployeeManagementDb;Integrated Security=True;";
    }
}