using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region DECLARE

        //IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService, IBaseRepository<Employee> baseRepository) : base(employeeService, baseRepository)
        {
            //_employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Lấy thông tin phân trang nhân viên
        /// </summary>
        /// <returns>Dữ liệu phân trang</returns>
        /// CreatedBy:PHDUONG(07/08/2021)
        [HttpGet("paging")]
        public IActionResult GetCustomersPaging([FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string employeeFilter, [FromQuery] Guid? departmentId, [FromQuery] Guid? positionId)
        {
            try
            {

                var serviceResult = _employeeService.GetPaging(pageIndex, pageSize, employeeFilter, departmentId, positionId);

                if ((int)serviceResult.Data.GetType().GetProperty("totalRecord").GetValue(serviceResult.Data) != 0)
                {
                    //4. Tra ve cho client
                    return StatusCode(200, serviceResult.Data);
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
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }

        }
        #endregion

    }
}
