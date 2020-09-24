using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.TaskAssigns;
using BCX_CORE.Objects.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCX_CORE.Objects.EmployeeTasks
{
    //Bridge Entity: N:N
    public class EmployeeTask : CommonEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
