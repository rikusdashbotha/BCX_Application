using BCX_CORE.DTOs;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.EmployeeTaskRepository
{
    public interface IEmployeeTaskRepository
    {
        Task<List<EmployeeTask>> GetListAsync();
        Task<EmployeeTask> GetEmployeeTask(int Id);

        Task<List<EmployeeTask>> GetEmployeeTasksByTaskId(int Id);

        Task<List<BCX_CORE.Objects.Tasks.Task>> GetTasksByEmployeeId(int Id);
        Task<EmployeeTask> UpdateEmployeeTask(int Id, EmployeeTask data);

        Task<EmployeeTask> InsertEmployeeTask(EmployeeTask data);

        Task<EmployeeTask> DeleteEmployeeTasksByTaskId(int Id);


    }
}
