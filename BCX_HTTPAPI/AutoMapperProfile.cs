using AutoMapper;
using BCX_CORE.DTOs.Employees;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.DTOs.Hours;
using BCX_CORE.DTOs.TaskAssigns;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;

namespace BCX_HTTPAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => 
                    dest.EmployeeTasks, opt => opt.MapFrom(src => src.EmployeeTasks)).ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<EmployeeTask, EmployeeTaskDto>().ReverseMap();

            CreateMap<BCX_CORE.Objects.Tasks.Task, TaskDto>().ReverseMap();
            CreateMap<TaskAssign, TaskAssignDto>().ReverseMap();

            CreateMap<Hour, HourDto>().ReverseMap();
        }
        
    }
}
