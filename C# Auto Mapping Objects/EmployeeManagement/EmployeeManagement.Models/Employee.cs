using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public Guid ManagerId { get; set; }
        public Employee Manager { get; set; }

        public List<Employee> ManagedEmployees { get; set; }
    }
}