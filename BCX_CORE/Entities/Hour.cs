﻿using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCX_CORE.Objects.Hours
{
    public class Hour : CommonEntity
    {
        

        [Required]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Hours Worked")]
        public double HoursWorked { get; set; }


        [DisplayName("Role Rate")]
        public double RoleRateAtTime { get; set; }

        public double Total { get; set; }

        [DisplayName("Date of Work")]
        [Required]
        public DateTime DateWorked { get; set; }

        public int TaskId { get; set; }



    }
}
