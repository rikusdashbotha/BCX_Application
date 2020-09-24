using BCX_CORE.Objects.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.ITaskRepository
{
    public interface ITaskRepository
    {
        Task<List<BCX_CORE.Objects.Tasks.Task>> GetListAsync();
        Task<BCX_CORE.Objects.Tasks.Task> GetTask(int Id);

        Task<BCX_CORE.Objects.Tasks.Task> UpdateTask(int Id, BCX_CORE.Objects.Tasks.Task data);
        Task<BCX_CORE.Objects.Tasks.Task> InsertTask(BCX_CORE.Objects.Tasks.Task data, CancellationToken cancellationToken);

    }
}
