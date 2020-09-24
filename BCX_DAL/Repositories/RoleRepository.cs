
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public BCX_DBContext _context { get; set; }
        public RoleRepository(BCX_DBContext context)
        {
            _context = context;
        }


        public async Task<Role> GetRole(int Id)
        {
            //Query the Roles Context for a specific record by ID
            return await _context.Roles.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Role>> GetListAsync(/*Consider Paging input model here*/)
        {
            //Query the Roles Context for all available Roles
            var test = await _context.Roles.ToListAsync();
            return test;
        }

        public async Task<Role> InsertRole(Role data, CancellationToken cancellationToken)
        {
            //Set the Created property and add Role to Roles context; Save Changes
            data.CreatedTS = DateTime.Now;
            var result =  await _context.Roles.AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Role> UpdateRole(int Id, Role data)
        {
            //Set the Updated property and update the tracked, modified Role entity; Save Changes
            try
            {
                data.UpdatedTS = DateTime.Now;
                _context.Attach(data).State = EntityState.Modified;
                var result = _context.Roles.Update(data);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception Ex)
            {

                throw;
            }
            
        }
    }
}
