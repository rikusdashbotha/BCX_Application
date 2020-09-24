using BCX_CORE.DTOs;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.HourRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
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
    public class HourRepository : IHourRepository
    {
        public BCX_DBContext _context { get; set; }
        public HourRepository(BCX_DBContext context)
        {
            _context = context;
        }

        public async Task<List<Hour>> GetListAsync()
        {
            return await _context.Hours.ToListAsync();
        }

        public async Task<Hour> GetHour(int employeeId, DateTime fromDate, DateTime toDate)
        {
            //Get list of Total hours per employee.
            //Build IQueryable with joined query based on specific ID, with filters for From and To Dates.
            //Select results into a custom Tuple Class for brevity
            var query = await  (from employee in _context.Employees
                join hour in _context.Hours on employee.Id equals hour.EmployeeId
                where hour.DateWorked < toDate && hour.DateWorked >= fromDate && employee.Id == employeeId
                select new TupleClass() { weirdClass = new Tuple<int, string, string, double>
                (employee.Id, employee.FirstName, employee.LastName, hour.Total) }).ToListAsync();

            //Determine the summed total for all rates worked
            var summed = query.Sum(p => p.weirdClass.Item4);
            
            //Build simple object to return to view
            Hour final = new Hour() { Employee = new Employee() 
            { 
                Id = query[0].weirdClass.Item1,
                FirstName = query[0].weirdClass.Item2,
                LastName = query[0].weirdClass.Item3
            },
                Total = summed
            };

            return final;
        }

        public async Task<Hour> InsertHour(Hour data)
        {            
            //Get employee rate
            //Since hour was not eagerly loaded, find related employee's role rate.
            var employee = await _context.Employees.Include(c => c.Role).FirstOrDefaultAsync(c => c.Id == data.EmployeeId);

            //Perform calculations
            data.RoleRateAtTime = employee.Role.RatePerHour;
            data.Total = data.RoleRateAtTime * data.HoursWorked;

            //Add the entity to the context and save changes
            var result =  await _context.Hours.AddAsync(data);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Hour> UpdateHour(int Id, Hour data)
        {
            //Update the updated property; Set tracked entity to Modified, update context with the entity and save changes
            try
            {
                data.UpdatedTS = DateTime.Now;
                _context.Attach(data).State = EntityState.Modified;
                var result = _context.Hours.Update(data);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception Ex)
            {

                throw;
            }
        }
    }

    public class TupleClass
    {
        public Tuple<int, string, string, double> weirdClass { get; set; }
    }
}
