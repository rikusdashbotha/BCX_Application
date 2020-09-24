using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.ITaskAssignRepository
{
    public interface ITaskAssignRepository
    {
        Task<List<TaskAssign>> GetListAsync();
        Task<TaskAssign> GetTaskAssign(int Id);

        Task<TaskAssign> UpdateTaskAssign(int Id, TaskAssign data);
        Task<TaskAssign> InsertTaskAssign(TaskAssign data, CancellationToken cancellationToken);

    }
}
