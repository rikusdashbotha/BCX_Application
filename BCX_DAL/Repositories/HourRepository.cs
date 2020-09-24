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

        public async Task<Hour> GetHour(/*Consider Paging input model here*/int employeeId, DateTime fromDate, DateTime toDate)
        {
            //Get list of Total hours per employee.

            //var query = from employee in _context.Employees
            //            join hour in _context.Hours on employee.Id equals hour.EmployeeId
            //            where (hour.DateWorked < toDate && hour.DateWorked >= fromDate && employee.Id == employeeId)
            //            select new { employee.Id, employee.FirstName, employee.LastName, hour.Total };

            var query = await  (from employee in _context.Employees
                                            join hour in _context.Hours on employee.Id equals hour.EmployeeId
                                            where hour.DateWorked < toDate && hour.DateWorked >= fromDate && employee.Id == employeeId
                                            select new TupleClass() { weirdClass = new Tuple<int, string, string, double>(employee.Id, employee.FirstName, employee.LastName, hour.Total) }).ToListAsync();



            //var actualrecord = query.ToList<TupleClass>();
            var summed = query.Sum(p => p.weirdClass.Item4);

            //var test = await _context.Hours
            //    //.Include(c => c.Role)
            //    .ToListAsync();
            
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
            var employee = await _context.Employees.Include(c => c.Role).FirstOrDefaultAsync(c => c.Id == data.EmployeeId);
            data.RoleRateAtTime = employee.Role.RatePerHour;
            data.Total = data.RoleRateAtTime * data.HoursWorked;

            var result =  await _context.Hours.AddAsync(data);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Hour> UpdateHour(int Id, Hour data)
        {
            try
            {
                _context.Attach(data).State = EntityState.Detached;
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
