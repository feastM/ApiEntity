using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.API.Domain.Services;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using AutoMapper;
using Users.API.Resources;
using Users.API.Extensions;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResource>> GetAllAsync()
        {
            var employee = await _employeeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employee);
        
            return resources;

           
        }

      
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.SaveAsync(employee);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUpdateEmployee resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveUpdateEmployee, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(categoryResource);
        }


    }
}
