using BCX_CORE.DTOs;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetListAsync();
        Task<Employee> GetEmployee(int Id);

        Task<Employee> UpdateEmployee(int Id, Employee data);

        Task<Employee> InsertEmployee(Employee data, CancellationToken cancellationToken);


    }
}
