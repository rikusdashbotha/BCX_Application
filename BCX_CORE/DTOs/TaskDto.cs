using BCX_CORE.Objects.TaskAssigns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BCX_CORE.DTOs.Tasks
{
    public class TaskDto : CommonEntity
    {
        public string Name { get; set; }

        public double Duration { get; set; }

        public TaskAssign TaskAssign { get; set; }
        public int TaskAssignId { get; set; }
    }

    public class TaskCollection
    {
        public List<TaskDto> Tasks { get; set; }
    }
}
