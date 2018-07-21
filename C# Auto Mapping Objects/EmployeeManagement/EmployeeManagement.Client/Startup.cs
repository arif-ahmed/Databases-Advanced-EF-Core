using System;
using AutoMapper;
using EmployeeManagement.Client.EntityMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Client
{
    class Startup
    {
        static EmployeeManagementDbContext db = new EmployeeManagementDbContext();

        static void Main()
        {
           
            AutoMapperConfiguration();

            var obj = new EmployeeDto
            {
                FirstName = "Arif",
                LastName = "Ahmed",
                Salary = 10000
            };

            AddEmployee(obj);
        }

        static void AutoMapperConfiguration()
        {
            Mapper.Initialize(config => config.CreateMap<EmployeeDto, Employee>()
            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dto => dto.Salary, opt => opt.MapFrom(src => src.Salary))            
            );

            Mapper.Initialize(
                config => config.CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.ManagedEmployees, opt => opt.MapFrom(src => src.ManagedEmployees))
                .ForMember(dto => dto.ManagedEmployeesCount, opt => opt.MapFrom(src => src.ManagedEmployees.Count))
                );
        }

        static void AddEmployee(EmployeeDto employeeDTO)
        {
            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDTO);
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        static void SetBirthday(Guid id, DateTime birthdate)
        {
            var emp = db.Employees.Find(id);
            emp.BirthDate = birthdate;
            db.SaveChanges();
        }

        static void ManagerInfo(Guid id)
        {
            var employee = db.Employees.Find(id);

            var managerInfo = Mapper.Map<Employee, ManagerDto>(employee);
        }
    }
}
