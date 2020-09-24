using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.EmployeeTaskRepository;
using BCX_CORE.Interfaces.ITaskRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeTasksAPIController : ControllerBase
    {

        private readonly ILogger<EmployeeTasksAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeTaskRepository _employeetaskRepository;

        public EmployeeTasksAPIController(ILogger<EmployeeTasksAPIController> logger, IMapper mapper, IEmployeeTaskRepository employeetaskRepository )
        {
            _logger = logger;
            _mapper = mapper;
            _employeetaskRepository = employeetaskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeTaskDto>> GetList()
        {
            var results = await _employeetaskRepository.GetListAsync();
            var conResults = _mapper.Map<List<EmployeeTaskDto>>(results);
            return conResults.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeTaskDto> GetEmployeeTask(int Id)
        {
            var results = await _employeetaskRepository.GetEmployeeTask(Id);
            var conResults = _mapper.Map<EmployeeTaskDto>(results);
            return conResults;
        }

        [HttpGet]
        [Route("EmployeeTasksByTaskId")]
        public async Task<EmployeeTaskCollection> GetEmployeeTasksByTaskId(int Id)
        {
            var results = await _employeetaskRepository.GetEmployeeTasksByTaskId(Id);
            EmployeeTaskCollection conResults = new EmployeeTaskCollection();
            conResults.EmployeeTasks = _mapper.Map<List<EmployeeTaskDto>>(results);
            conResults.EmployeeTasks.ToList().ForEach(c => c.Employee.EmployeeTasks = null);
            return conResults;
        }

        [HttpGet]
        [Route("TasksByEmployeeId")]
        public async Task<TaskCollection> GetTasksByEmployeeId(int Id)
        {
            var results = await _employeetaskRepository.GetTasksByEmployeeId(Id);
            TaskCollection conResults = new TaskCollection();
            conResults.Tasks = _mapper.Map<List<TaskDto>>(results);
            //conResults.Tasks.ToList().ForEach(c => c.);
            return conResults;
        }

        [HttpPut]
        public async Task<HttpStatusCode> AddEmployeeTasks(EmployeeTaskCollection data)
        {
            //Step through collection and add employeetasks accordingly
            try
            {
                foreach (var empTask in data.EmployeeTasks)
                {
                    await _employeetaskRepository.InsertEmployeeTask(_mapper.Map<EmployeeTask>(empTask));
                }
            }
            catch (Exception Ex)
            { throw; }
            
            //var result = await _employeetaskRepository.InsertEmployeeTask(_mapper.Map<EmployeeTask>(data), cancellationToken);
            return HttpStatusCode.OK;// _mapper.Map<TaskDto>(result);
        }

        [HttpPost]
        //[Route("{id}")]
        public async Task<HttpStatusCode> UpdateEmployeeTask(EmployeeTaskCollection data)
        {
            try
            {
                if (data.EmployeeTasks?.Count > 0)
                {
                    //Wipe current entries first
                    await _employeetaskRepository.DeleteEmployeeTasksByTaskId(data.TaskId);

                    //Re-add Entries from Dto
                    foreach (var empTask in data.EmployeeTasks)
                    {
                        await _employeetaskRepository.InsertEmployeeTask(_mapper.Map<EmployeeTaskDto, EmployeeTask>(empTask));
                    }
                    return HttpStatusCode.OK;
                }
                return HttpStatusCode.NotFound;
            }
            catch (Exception)
            { throw; }
        }
    }
}
