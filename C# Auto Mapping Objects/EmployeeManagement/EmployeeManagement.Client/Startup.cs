using System;
using AutoMapper;
using EmployeeManagement.Client.EntityMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Client
{
    class Startup
    {
        static void Main()
        {
            Mapper.Initialize(config => config.CreateMap<EmployeeDTO, Employee>().ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName + "HHH")));

            var obj = new EmployeeDTO
            {
                FirstName = "Arif",
                LastName = "Ahmed",
                Salary = 10000
            };

            var res = Mapper.Map<EmployeeDTO, Employee>(obj);

            Console.WriteLine();



/*            using (var db = new EmployeeManagementDbContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
            }*/
        }
    }
}
