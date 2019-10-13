using IntroductionToEntityFramework.Data;
using System;
using System.Text;
using System.Linq;

using IntroductionToEntityFramework.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IntroductionToEntityFramework
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                // Console.WriteLine(GetEmployeesFullInformation(context));
                // Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
                // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
                //Console.WriteLine(AddNewAddressToEmployee(context));
                //Console.WriteLine(GetAddressesByTown(context));
                //Console.WriteLine(GetEmployeesInPeriod());
                //Console.WriteLine(GetDepartmentsWithMoreThan5Employees());
                IncreaseSalaries();

            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.OrderBy(employee => employee.EmployeeId);

            foreach (var employee in employees)
            {
                sb.Append($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle}");
                sb.Append(" ");
                sb.Append(String.Format("{0:0.00}", employee.Salary));
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(employee => employee.Salary > 50000).OrderBy(employee => employee.FirstName).Select(employee => new { employee.FirstName, employee.Salary }).ToList();

            employees.ForEach(emp =>
            {
                sb.Append($"{emp.FirstName} - " + String.Format("{0:0.00}", emp.Salary));
                sb.Append("\n");
            });

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //            var employees = (from employee in context.Employees
            //                            join
            //department in context.Departments on employee.DepartmentId equals department.DepartmentId
            //                            where department.Name == "Research and Development"
            //                            orderby employee.Salary ascending
            //                            orderby employee.FirstName descending
            //                            select new
            //                            {
            //                                employee.FirstName,
            //                                employee.LastName,
            //                                DepartmentName = department.Name,
            //                                employee.Salary
            //                            }).ToList();

            var employees = context.Employees.Where(employee => employee.Department.Name == "Research and Development")
                .OrderBy(employee => employee.Salary)
                .ThenByDescending(employee => employee.FirstName)
                .Select(employee => new 
                {
                    employee.FirstName,
                    employee.LastName,
                    DepartmentName = employee.Department.Name,
                    employee.Salary
                })
                .ToList();

            employees.ForEach(emp =>
            {
                sb.Append($"{emp.FirstName} - " + String.Format("{0:0.00}", emp.Salary));
                sb.Append("\n");
            });


            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var address = new Address { AddressText = "", TownId = 4};

            var employee = context.Employees.FirstOrDefault(emp => emp.LastName == "Nakov");
            employee.Address = address;

            context.SaveChanges();

            var addressTexts = context.Employees.OrderByDescending(emp => emp.AddressId).Take(10).Select(emp => emp.Address.AddressText).ToList();

            addressTexts.ForEach(addressText => {
                sb.Append(addressText);
                sb.Append("\n");
            });

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new { Employees = a.Employees.Count, Town = a.Town.Name, a.AddressText })
                .OrderByDescending(x => x.Employees)
                .ThenBy(x => x.Town)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(t => t.AddressText + " " + t.Town + " " + t.Employees).ToList();

            addresses.ForEach(address => {
                sb.Append(address);
                sb.Append("\n");
            });

            return sb.ToString();
        }

        //Employees and Projects
        public static string GetEmployeesInPeriod()
        {
            StringBuilder sb = new StringBuilder();

            using (SoftUniContext dbContext = new SoftUniContext())
            {
                var employees = dbContext.Employees.Include(emp => emp.Manager).Include(emp => emp.EmployeeProjects)
                    .Where(emp => emp.EmployeeProjects.Any(empProj => empProj.Project.StartDate.Year >= 2001 && empProj.Project.StartDate.Year <= 2003))
                    .Select(emp => new
                    {
                        emp.FirstName,
                        emp.LastName,
                        emp.Manager,
                        Projects = emp.EmployeeProjects.Select(empProj => new { empProj.Project.Name, empProj.Project.StartDate, empProj.Project.EndDate })
                    }).ToList();

                foreach (var employee in employees)
                {
                    sb.Append($"{employee.FirstName} {employee.LastName}");
                    sb.Append(" ");

                    if (employee.Manager != null)
                    {
                        sb.Append($"Manager - {employee.Manager.FirstName} {employee.Manager.LastName}");
                    }
                    else
                    {
                        sb.Append($"No Manager");
                    }

                    foreach (var project in employee.Projects)
                    {
                        sb.Append("\n");

                        if(project.EndDate != null)
                        {
                            sb.Append($"--{project.Name} {project.StartDate} {project.EndDate}");
                        }
                        else
                        {
                            sb.Append($"--{project.Name} {project.StartDate} not finished");
                        }
                    }

                    sb.Append("\n\n");
                }



            }

            return sb.ToString();
        }

        //Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees()
        {
            StringBuilder sb = new StringBuilder();

            using(var db = new SoftUniContext())
            {
                var departments = db.Departments
                    .Where(dept => dept.Employees.Count > 5)
                    .Select(dept => new { dept.Name, dept.Manager, dept.Employees })
                    .OrderBy(dept => dept.Employees.Count)
                    .ThenBy(dept => dept.Name)
                    .ToList();

                foreach (var department in departments)
                {
                    sb.Append($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");
                    sb.Append("\n");

                    var employees = department.Employees.OrderBy(emp => emp.FirstName).ThenBy(emp => emp.LastName);

                    foreach (var employee in employees)
                    {
                        sb.Append($"{employee.FirstName} {employee.LastName}");
                        sb.Append("\n");
                    }

                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }

        // Increase Salaries
        public static string IncreaseSalaries()
        {
            StringBuilder sb = new StringBuilder();

            List<string> departmentNames = new List<string>() { "Engineering", "Tool Design", "Marketing", "Information Services" };


            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Where(emp => emp.Departments.Any(dept => departmentNames.Contains(dept.Name))).ToList();
            }

            return sb.ToString();
        }
    }
}
