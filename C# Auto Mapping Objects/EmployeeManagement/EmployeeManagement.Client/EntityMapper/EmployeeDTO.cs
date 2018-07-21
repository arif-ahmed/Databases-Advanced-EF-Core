using System;

namespace EmployeeManagement.Client.EntityMapper
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}