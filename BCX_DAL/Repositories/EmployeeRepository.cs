using BCX_CORE.DTOs;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Objects.Employees;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public BCX_DBContext _context { get; set; }
        public EmployeeRepository(BCX_DBContext context)
        {
            _context = context;
        }


        public async Task<Employee> GetEmployee(int Id)
        {
            return await _context.Employees.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Employee>> GetListAsync(/*Consider Paging input model here*/)
        {
            var test = await _context.Employees
                .Include(c => c.Role)
                .ToListAsync();
            return test;
        }

        public async Task<Employee> InsertEmployee(Employee data, CancellationToken cancellationToken)
        {
            var result =  await _context.Employees.AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Employee> UpdateEmployee(int Id, Employee data)
        {
            try
            {
                _context.Attach(data).State = EntityState.Detached;
                var result = _context.Employees.Update(data);
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
