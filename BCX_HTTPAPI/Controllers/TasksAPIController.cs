using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.ITaskRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksAPIController : ControllerBase
    {

        private readonly ILogger<TasksAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TasksAPIController(ILogger<TasksAPIController> logger, IMapper mapper, ITaskRepository taskRepository )
        {
            _logger = logger;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDto>> GetList()
        {
            var results = await _taskRepository.GetListAsync();
            var conResults = _mapper.Map<List<TaskDto>>(results);
            return conResults.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TaskDto> GetTask(int Id)
        {
            var results = await _taskRepository.GetTask(Id);
            var conResults = _mapper.Map<TaskDto>(results);
            return conResults;
        }

        [HttpPut]
        public async Task<HttpStatusCode> AddTask(TaskDto data, CancellationToken cancellationToken)
        {
            var result = await _taskRepository.InsertTask(_mapper.Map<BCX_CORE.Objects.Tasks.Task>(data), cancellationToken);
            return HttpStatusCode.OK;// _mapper.Map<TaskDto>(result);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpStatusCode> UpdateTask(int id, TaskDto data)
        {
            var result = await _taskRepository.UpdateTask(id, _mapper.Map<BCX_CORE.Objects.Tasks.Task>(data));
            return HttpStatusCode.OK; //_mapper.Map<TaskDto>(result);
        }
    }
}
