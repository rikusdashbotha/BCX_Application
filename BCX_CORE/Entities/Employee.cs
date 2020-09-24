using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using BCX_CORE.Objects.Tasks;

namespace BCX_CORE.Objects.Employees
{
    public class Employee : CommonEntity
    {
        [Required]
        [MinLength(1, ErrorMessage = "First Name must be atleast 2 characters long")]
        [MaxLength(50, ErrorMessage = "First Name may not exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Last Name must be atleast 2 characters long")]
        [MaxLength(50, ErrorMessage = "Last Name may not exceed 50 characters")]
        public string LastName { get; set; }

        public string ImagePath { get; set; }
        //Nav Props
        
        public Role Role { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }


        public ICollection<EmployeeTask> EmployeeTasks { get; set; }

        public ICollection<Hour> Hours { get; set; }

    }
}
