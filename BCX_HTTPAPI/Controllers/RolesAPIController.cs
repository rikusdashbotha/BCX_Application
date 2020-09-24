using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.RoleRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesAPIController : ControllerBase
    {

        private readonly ILogger<RolesAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RolesAPIController(ILogger<RolesAPIController> logger, IMapper mapper, IRoleRepository roleRepository )
        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleDto>> GetList()
        {
            var results = await _roleRepository.GetListAsync();
            var conResults = _mapper.Map<List<RoleDto>>(results);
            return conResults.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<RoleDto> GetRole(int Id)
        {
            var results = await _roleRepository.GetRole(Id);
            var conResults = _mapper.Map<RoleDto>(results);
            return conResults;
        }

        [HttpPut]
        public async Task<HttpStatusCode> AddRole(RoleDto data, CancellationToken cancellationToken)
        {
            var result = await _roleRepository.InsertRole(_mapper.Map<Role>(data), cancellationToken);
            return HttpStatusCode.OK;//_mapper.Map<RoleDto>(result);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpStatusCode> UpdateRole(int id, RoleDto data)
        {
            var result = await _roleRepository.UpdateRole(id, _mapper.Map<Role>(data));
            return HttpStatusCode.OK;// _mapper.Map<RoleDto>(result);
        }
    }
}
