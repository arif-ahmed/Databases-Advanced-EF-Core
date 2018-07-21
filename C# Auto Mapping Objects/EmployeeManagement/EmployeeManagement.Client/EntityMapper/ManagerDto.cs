using System.Collections.Generic;

namespace EmployeeManagement.Client.EntityMapper
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagedEmployees { get; set; }

        public int ManagedEmployeesCount { get; set; }
    }
}