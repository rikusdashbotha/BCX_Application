using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.DTOs.TaskAssigns;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.ITaskAssignRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskAssignAPIsController : ControllerBase
    {

        private readonly ILogger<TaskAssignAPIsController> _logger;
        private readonly IMapper _mapper;
        private readonly ITaskAssignRepository _taskAssignRepository;

        public TaskAssignAPIsController(ILogger<TaskAssignAPIsController> logger, IMapper mapper, ITaskAssignRepository taskAssignRepository )
        {
            _logger = logger;
            _mapper = mapper;
            _taskAssignRepository = taskAssignRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskAssignDto>> GetList()
        {
            var results = await _taskAssignRepository.GetListAsync();
            var conResults = _mapper.Map<List<TaskAssignDto>>(results);
            return conResults.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TaskAssignDto> GetTaskAssign(int Id)
        {
            var results = await _taskAssignRepository.GetTaskAssign(Id);
            var conResults = _mapper.Map<TaskAssignDto>(results);
            return conResults;
        }

        [HttpPut]
        public async Task<TaskAssignDto> AddTaskAssign(TaskAssignDto data, CancellationToken cancellationToken)
        {
            var result = await _taskAssignRepository.InsertTaskAssign(_mapper.Map<TaskAssign>(data), cancellationToken);
            return _mapper.Map<TaskAssignDto>(result);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<TaskAssignDto> UpdateTaskAssign(int id, TaskAssignDto data)
        {
            var result = await _taskAssignRepository.UpdateTaskAssign(id, _mapper.Map<TaskAssign>(data));
            return _mapper.Map<TaskAssignDto>(result);
        }
    }
}
