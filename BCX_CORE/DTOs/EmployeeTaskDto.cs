using BCX_CORE.DTOs.Employees;
using BCX_CORE.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCX_CORE.DTOs.EmployeeTasks
{
    public class EmployeeTaskDto : CommonEntity
    {
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }

        public int TaskId { get; set; }
        public TaskDto Task { get; set; }
    }

    public class EmployeeTaskCollection
    {
        public ICollection<EmployeeTaskDto> EmployeeTasks { get; set; }
        public int TaskId { get; set; }

    }
}
