using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BCX_CORE.Objects.Roles
{
    public class RoleDto : CommonEntity
    {
        public string Name { get; set; }
        [DisplayName("Rate Per Hour")]
        public double RatePerHour { get; set; }

        [MaybeNull]
        public Employee Employee { get; set; }
        [MaybeNull]
        public Hour Hour { get; set; }
    }

    public class RoleCollection
    {
        public List<RoleDto> Roles { get; set; }
    }
}
