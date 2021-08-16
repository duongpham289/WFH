using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Services;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {

        ICustomerRepository _customerRepository;
        ICustomerService _customerService;

        public CustomersController(ICustomerRepository customerRepository, ICustomerService customerService)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }

        // GET, POST, PUT, DELETE

        /// <summary>
        /// Lấy danh sách Khách hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns>Danh sách khách hàng dạng Json</returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {

            try
            {
                var customers = _customerRepository.GetAll();

                //4. Trả dữ liệu cho client
                if (customers.Count > 0)
                {
                    return StatusCode(200, customers);
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
        /// Lấy thông tin Khách hàng theo Id
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns>Thông tin Khách hàng dạng Json</returns>
        [HttpGet("{customerId}")]
        public IActionResult GetCustomersById(Guid customerId)
        {
            try
            {

                //3. Lay du lieu:
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customerId);
                //var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", param: parameters, commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                //if (customer != null)
                //{
                //    return StatusCode(200, customer);

                //}
                //else
                //{
                return NoContent();
                //}
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
        /// Lấy thông tin phân trang Khách hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns>Dữ liệu phân trang</returns>
        [HttpGet("paging")]
        public IActionResult GetCustomersPaging([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            try
            {
                //3. Lay du lieu:
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PageIndex", pageIndex);
                parameters.Add("@pageSize", pageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

                //var customerPagingData = dbConnection.Query<Customer>("Proc_CustomersPaging", param: parameters, commandType: CommandType.StoredProcedure);

                //if (customerPagingData.Count() > 1)
                //{
                //    //4. Tra ve cho client
                //    return StatusCode(200, customerPagingData);
                //}
                //else
                //{
                return NoContent();
                //}

                //var response = StatusCode(200, parameters.Get<Int32>("@TotalPage"));
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
        /// Thêm Khách Hàng vào cơ sở dữ liệu
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            try
            {
                var serviceReSult = _customerService.Add(customer);

                //4. Trả dữ liệu cho client
                if (serviceReSult.IsValid == true)
                {
                    return StatusCode(200, serviceReSult.Data);

                }
                else
                {
                    return BadRequest(serviceReSult.Data);
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
        /// Sửa Khách Hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(Customer customer, Guid customerId)
        {
            try
            {
                var serviceReSult = _customerService.Update(customer, customerId);

                //4. Tra ve cho client
                if (serviceReSult.IsValid == true)
                {
                    return StatusCode(200, serviceReSult.Data);
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
        /// Xóa Khách hàng 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            try
            {

                //3. Lay du lieu:
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customerId);
                //var rowsEffect = dbConnection.Execute("Proc_DeleteCustomer", param: parameters, commandType: CommandType.StoredProcedure);

                ////4. Tra ve cho client
                //if (rowsEffect > 0)
                //{
                //    return StatusCode(200, rowsEffect);
                //}
                //else
                //{
                return NoContent();
                //}
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
    }
}
