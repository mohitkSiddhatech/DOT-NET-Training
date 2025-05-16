using AutoMapper;
using EmployeeManagementCRUD.DTOs;
using EmployeeManagementCRUD.Models;

namespace EmployeeManagementCRUD.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            // Using ReverseMap(), we can use both way mapping using single declaration.
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}
