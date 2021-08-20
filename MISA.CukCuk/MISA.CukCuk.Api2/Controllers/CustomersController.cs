using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MISA.Core.Interfaces.Services;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System.Threading;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class CustomersController : BaseEntityController<Customer>
    {
        #region DECLARE

        //ICustomerRepository _customerRepository;
        ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomersController(ICustomerService customerService, IBaseRepository<Customer> baseRepository) : base(customerService, baseRepository)
        {
            //_customerRepository = customerRepository;
            _customerService = customerService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy thông tin phân trang Khách hàng
        /// </summary>
        /// <returns>Dữ liệu phân trang</returns>
        /// CreatedBy:PHDUONG(07/08/2021)
        [HttpGet("paging")]
        public IActionResult GetCustomersPaging([FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string customerFilter, [FromQuery] Guid? customerGroupId)
        {
            try
            {

                var serviceResult = _customerService.GetPaging(pageIndex, pageSize, customerFilter, customerGroupId);

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


        /// <summary>
        /// Thêm danh sách Khách hàng từ file Excel
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(20/08/2021)
        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile, CancellationToken cancellationToken)
        {
            try
            {
                var serviceResult = _customerService.ImportCustomer(formFile, cancellationToken);
                return StatusCode(200, serviceResult.Data);
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
