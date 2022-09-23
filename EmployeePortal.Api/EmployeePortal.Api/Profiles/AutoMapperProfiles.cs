using AutoMapper;
using EmployeePortal.Api.DomainModels;

namespace EmployeePortal.Api.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Employee, Employee>().ReverseMap();
            CreateMap<AddEmployee, DataModels.Employee>();
            CreateMap<UpdateEmployee, DataModels.Employee>();
        }
    }
}