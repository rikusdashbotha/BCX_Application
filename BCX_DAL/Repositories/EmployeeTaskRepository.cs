using BCX_CORE.DTOs;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.EmployeeTaskRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_DAL.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        public BCX_DBContext _context { get; set; }
        public EmployeeTaskRepository(BCX_DBContext context)
        {
            _context = context;
        }

        public async Task<EmployeeTask> GetEmployeeTask(int Id)
        {
            return await _context.EmployeeTasks.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<EmployeeTask>> GetEmployeeTasksByTaskId(int Id)
        {
            var results = _context.EmployeeTasks
                //.Include(c => c.Task)
                .Include(c => c.Employee)
                .AsNoTracking();
            results = results.Where(c => c.TaskId == Id);
            return await results.ToListAsync<EmployeeTask>();
        }

        public async Task<List<BCX_CORE.Objects.Tasks.Task>> GetTasksByEmployeeId(int Id)
        {
            var results = _context.EmployeeTasks
                .Include(c => c.Task)
                .Include(c => c.Employee)
                //TEST
                .AsNoTracking();
            var newResults = await results.Where(c => c.EmployeeId == Id).Select(e => e.Task).ToListAsync();
            return newResults;
        }

        public async Task<List<EmployeeTask>> GetListAsync(/*Consider Paging input model here*/)
        {
            var test = await _context.EmployeeTasks.ToListAsync();
            return test;
        }

        public async Task<EmployeeTask> InsertEmployeeTask(EmployeeTask data)
        {
            data.CreatedTS = DateTime.Now;
            var result =  await _context.EmployeeTasks.AddAsync(data);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<EmployeeTask> UpdateEmployeeTask(int Id, EmployeeTask data)
        {
            try
            {
                data.UpdatedTS = DateTime.Now;
                _context.Attach(data).State = EntityState.Detached;
                var result = _context.EmployeeTasks.Update(data);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception Ex)
            { throw; }
            
        }

        public async Task<EmployeeTask> DeleteEmployeeTasksByTaskId(int Id)
        {
            try
            {
                var empTasks = await GetEmployeeTasksByTaskId(Id);
                empTasks.ForEach(c => c.UpdatedTS = DateTime.Now);
                foreach (var empTask in empTasks)
                {
                    _context.Attach(empTask).State = EntityState.Deleted;
                    _context.EmployeeTasks.Remove(empTask);

                }
                //_context.Attach(empTasks[0]).State = EntityState.Detached;
                //_context.EmployeeTasks.RemoveRange(empTasks);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception Ex)
            { throw; }
        }
    }
}
