using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.TaskAssigns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCX_CORE.Objects.Roles
{
    public class Role : CommonEntity
    {
        [Required]
        [MinLength(1, ErrorMessage = "Role Name must be atleast 1 character long")]
        [MaxLength(50, ErrorMessage = "Role Name may not exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        public double RatePerHour { get; set; }

        public Employee Employee { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Hour Hour { get; set; }


    }
}
