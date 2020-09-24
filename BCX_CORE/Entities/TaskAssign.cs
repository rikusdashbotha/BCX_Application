using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.Tasks;
using BCX_CORE.Objects.Hours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCX_CORE.Objects.TaskAssigns
{
    public class TaskAssign : CommonEntity
    {
        [Required]
        public Task Task { get; set; }
        public int TaskId { get; set; }

        [Required]
        public ICollection<Employee> Employees { get; set; }
        public int EmployeeId { get; set; }

        //[Required]
        //public Role RoleRef { get; set; }
        //public int RoleId { get; set; }

        //[Required]
        //public double HoursLogged { get; set; }

        public double AtCurrentRate { get; set; }

        public ICollection<Hour> Hours { get; set; }
    }
}
