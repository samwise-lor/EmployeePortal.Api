using AutoMapper;
using EmployeePortal.Api.DomainModels;
using EmployeePortal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeePortal.Api.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllEmployees()
        {
            var employees =  _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<List<Employee>>(employees));
        }
        
        /// <summary>
        /// Retrieves an employee object given an employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/{employeeId:guid}"), ActionName("GetEmployee")]
        public IActionResult GetEmployee([FromRoute] Guid employeeId)
        {
            var employee =  _employeeRepository.GetEmployee(employeeId);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<Employee>(employee));
        }
        
        /// <summary>
        /// Returns a list of employees given a set of parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/Search")]
        public IActionResult SearchEmployees([FromQuery] DomainModels.SearchEmployee request)
        {
            var employees =  _employeeRepository.SearchEmployee(_mapper.Map<DataModels.Employee>(request));
            return Ok(_mapper.Map<List<Employee>>(employees));
        }
        
        /*
         * Options to return response are
         * Created()
         * OK() with the object that was created
         */
        /// <summary>
        /// Creates an employee given employee object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]/Add")]
        public IActionResult AddEmployee([FromBody] DomainModels.AddEmployee request)
        {
            var currentEmployee =  _employeeRepository.DuplicateEmployee(request.FirstName, request.LastName, request.Email);
            if (currentEmployee) return Conflict(new { message = $"An existing record with the firstName: '{request.FirstName}', lastName: '{request.LastName}' and/or email: '{request.Email}' was already found."});
            var employee =  _employeeRepository.AddEmployee(_mapper.Map<DataModels.Employee>(request));
            return Ok(_mapper.Map<Employee>(employee));
        }
        
        /// <summary>
        /// Updates an employee given an employeeId and employee object
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[controller]/{employeeId:guid}")]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeId, [FromBody] UpdateEmployee request)
        {
            if (! _employeeRepository.Exists(employeeId)) return NotFound();
            var updatedEmployee =  _employeeRepository.UpdateEmployee(employeeId, _mapper.Map<DataModels.Employee>(request));
            if (updatedEmployee == null) return NotFound();
            return Ok(_mapper.Map<Employee>(updatedEmployee));
        }
        
        /*
         * Options to return response are
         * Ok()
         * OK() with the object that was deleted
         */
        /// <summary>
        /// Deletes and employee given a employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[controller]/{employeeId:guid}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeId)
        {
            if (! _employeeRepository.Exists(employeeId)) return NotFound();
            _employeeRepository.DeleteEmployee(employeeId);
            return NoContent();
        }
    }
}
