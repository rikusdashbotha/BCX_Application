using BCX_CORE.DTOs;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_CORE.Interfaces.HourRepository
{
    public interface IHourRepository
    {
        Task<Hour> GetHour(int employeeId, DateTime fromDate, DateTime toDate);
        
        Task<List<Hour>> GetListAsync();

        Task<Hour> UpdateHour(int Id, Hour data);

        Task<Hour> InsertHour(Hour data);


    }
}
