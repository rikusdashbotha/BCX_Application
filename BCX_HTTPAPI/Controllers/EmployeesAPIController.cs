using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.DTOs.Employees;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Objects.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesAPIController : ControllerBase
    {

        private readonly ILogger<EmployeesAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesAPIController(ILogger<EmployeesAPIController> logger, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetList()
        {
            var results = await _employeeRepository.GetListAsync();
            var conResults = _mapper.Map<List<EmployeeDto>>(results);
            return conResults.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto> GetEmployee(int Id)
        {
            var results = await _employeeRepository.GetEmployee(Id);
            var conResults = _mapper.Map<EmployeeDto>(results);
            return conResults;
        }

        [HttpPut]
        public async Task<HttpStatusCode> AddEmployee(EmployeeDto data, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.InsertEmployee(_mapper.Map<Employee>(data), cancellationToken);
            return HttpStatusCode.OK; // _mapper.Map<EmployeeDto>(result);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpStatusCode> UpdateEmployee(int id, EmployeeDto data)
        {
            var result = await _employeeRepository.UpdateEmployee(id, _mapper.Map<Employee>(data));
            return HttpStatusCode.OK;// _mapper.Map<EmployeeDto>(result);
        }
    }
}
