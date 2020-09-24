
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.TaskAssigns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCX_CORE.Objects.Tasks
{
    public class Task : CommonEntity
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character long")]
        [MaxLength(20, ErrorMessage = "Name may not exceed 20 characters")]
        public string Name { get; set; }
        [Required]
        public double Duration { get; set; }

        //public TaskAssign TaskAssign { get; set; }

        //Test
        //public ICollection<TaskAssign> TaskAssigns { get; set; }

        public ICollection<EmployeeTask> EmployeeTasks { get; set; }

        //public int TaskAssignId { get; set; }
    }
}
