using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BCX_CORE.DTOs.Employees
{
    public class EmployeeDto : CommonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaybeNull]
        [DisplayName("Current Image")]
        public string ImagePath { get; set; }
        public int RoleId { get; set; }
        [MaybeNull]
        public ICollection<TaskAssign> TaskAssigns { get; set; }

        [MaybeNull]
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }

        [DisplayName("Upload File")]
        [MaybeNull]
        public IFormFile ImageFile { get; set; }

        //Test
        [MaybeNull]
        public RoleDto Role { get; set; }

    }

    public class EmployeeCollection
    {
        public List<EmployeeDto> Employees { get; set; }

    }
}
