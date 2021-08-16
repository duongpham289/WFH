using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var employees = _employeeRepository.GetAll();
                if (employees.Count > 0)
                {
                    return StatusCode(200, employees);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                var res = _employeeService.Add(employee);
                if (res.IsValid == true)
                {
                    return Ok(res.Data);
                }
                else
                {
                    return BadRequest(res);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
