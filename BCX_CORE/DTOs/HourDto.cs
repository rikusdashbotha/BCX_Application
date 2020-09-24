using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BCX_CORE.DTOs.Hours
{
    public class HourDto : CommonEntity
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [DisplayName("Hours Worked")]
        public double HoursWorked { get; set; }

        [DisplayName("Role Rate")]
        public double RoleRateAtTime { get; set; }

        public double Total { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateWorked { get; set; }


        public int TaskId { get; set; }




    }

    public class HourCollection
    {
        public List<HourDto> Hours { get; set; }

    }
}
