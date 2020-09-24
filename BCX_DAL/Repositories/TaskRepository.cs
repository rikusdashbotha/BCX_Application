
using BCX_CORE.Interfaces.ITaskRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.Tasks;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public BCX_DBContext _context { get; set; }
        public TaskRepository(BCX_DBContext context)
        {
            _context = context;
        }


        public async Task<BCX_CORE.Objects.Tasks.Task> GetTask(int Id)
        {
            //Query the context for a specific Task by Id
            return await _context.Tasks.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<BCX_CORE.Objects.Tasks.Task>> GetListAsync(/*Consider Paging input model here*/)
        {
            //Query the context for all tasks
            var test = await _context.Tasks.ToListAsync();
            return test;
        }

        public async Task<BCX_CORE.Objects.Tasks.Task> InsertTask(BCX_CORE.Objects.Tasks.Task data, CancellationToken cancellationToken)
        {
            //Update the Created property; Add the new entity and pass the cancellationToken received from the HTTPAPI layer. Save changes
            data.CreatedTS = DateTime.Now;
            var result =  await _context.Tasks.AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<BCX_CORE.Objects.Tasks.Task> UpdateTask(int Id, BCX_CORE.Objects.Tasks.Task data)
        {
            //Update the Updated property, set the state of the tracked entity to Modified; Update the entity and save those changes
            try
            {
                data.UpdatedTS = DateTime.Now;
                _context.Attach(data).State = EntityState.Modified;
                var result = _context.Tasks.Update(data);
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
