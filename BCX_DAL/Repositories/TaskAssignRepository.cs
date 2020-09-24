
using BCX_CORE.Interfaces.ITaskAssignRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_DAL.Repositories
{
    public class TaskAssignRepository : ITaskAssignRepository
    {
        public BCX_DBContext _context { get; set; }
        public TaskAssignRepository(BCX_DBContext context)
        {
            _context = context;
        }

        public async Task<TaskAssign> GetTaskAssign(int Id)
        {
            return await _context.TaskAssigns.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<TaskAssign>> GetListAsync(/*Consider Paging input model here*/)
        {
            var test = await _context.TaskAssigns.ToListAsync();
            return test;
        }

        public async Task<TaskAssign> InsertTaskAssign(TaskAssign data, CancellationToken cancellationToken)
        {
            data.CreatedTS = DateTime.Now;
            var result =  await _context.TaskAssigns.AddAsync(data, cancellationToken);
            return null;
        }

        public async Task<TaskAssign> UpdateTaskAssign(int Id, TaskAssign data)
        {
            try
            {
                data.UpdatedTS = DateTime.Now;
                _context.Attach(data).State = EntityState.Detached;
                var result = _context.TaskAssigns.Update(data);
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
