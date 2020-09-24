using BCX_CORE.DTOs.Employees;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.TaskAssigns;
using BCX_CORE.Objects.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BCX_CORE.DTOs.TaskAssigns
{
    public class TaskAssignDto : CommonEntity
    {
        public Task Task { get; set; }

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }

        public List<EmployeeDto>? Employees { get; set; }
        public EmployeeDto Employee { get; set; }
        public int EmployeeId { get; set; } //This will reference the actual employeeId

        public double AtCurrentRate { get; set; }

        public ICollection<Hour> Hours { get; set; }
    }

    public class TaskAssignCollection
    {
        public List<TaskAssignDto> TaskAssigns { get; set; }
    }
}
