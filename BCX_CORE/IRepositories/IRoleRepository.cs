using BCX_CORE.Objects.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.RoleRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetListAsync();
        Task<Role> GetRole(int Id);

        Task<Role> UpdateRole(int Id, Role data);
        Task<Role> InsertRole(Role data, CancellationToken cancellationToken);

    }
}
