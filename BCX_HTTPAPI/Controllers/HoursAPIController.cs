using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BCX_CORE.DTOs;
using BCX_CORE.DTOs.Employees;
using BCX_CORE.DTOs.Hours;
using BCX_CORE.Interfaces.EmployeeRepository;
using BCX_CORE.Interfaces.HourRepository;
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.Hours;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCX_HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoursAPIController : ControllerBase
    {

        private readonly ILogger<HoursAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IHourRepository _hourRepository;

        public HoursAPIController(ILogger<HoursAPIController> logger, IMapper mapper, IHourRepository hourRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hourRepository = hourRepository;
        }

        [HttpGet]
        public async Task<HourDto> GetList()
        {
            var results = await _hourRepository.GetListAsync();
            var conResults = _mapper.Map<HourDto>(results);
            return conResults;//.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HourDto> GetHour(int Id)
        {
            var results = await _hourRepository.GetHour(Id, DateTime.Now.AddDays(-5), DateTime.Now); //Dated placed here for brevity.
            var conResults = _mapper.Map<HourDto>(results);
            return conResults;
        }

        [HttpPut]
        public async Task<HttpStatusCode> AddHour(HourDto data)
        {
            var result = await _hourRepository.InsertHour(_mapper.Map<Hour>(data));
            return HttpStatusCode.OK;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpStatusCode> UpdateHour(int id, EmployeeDto data)
        {
            var result = await _hourRepository.UpdateHour(id, _mapper.Map<Hour>(data));
            return HttpStatusCode.OK;
        }
    }
}
