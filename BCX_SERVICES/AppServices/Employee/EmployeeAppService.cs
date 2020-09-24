using BCX_CORE.Interfaces.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BCX_CORE.Objects.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetListAsync()
        {
            return await _employeeRepository.GetListAsync();
        }


    }
}
