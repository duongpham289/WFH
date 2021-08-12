using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Api.Models;
using System.Data;
using MySqlConnector;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Kết nối Database
        /// Author:PHDUONG(12/08/2021)
        /// </summary>
        /// <param name="configuration"></param>
        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection"));
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
                //3. Lay du lieu:
                var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                if (customers.Count() > 0)
                {
                    var response = StatusCode(200, customers);
                    return response;
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
                    userMsg = Properties.Resources.Server_ErrorMsg,
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
                var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", param: parameters, commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                if (customer != null)
                {
                    return StatusCode(200, customer);

                }
                else
                {
                    return NoContent();
                }
                var response = StatusCode(200, customer);
                return response;
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Server_ErrorMsg,
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

                var customerPagingData = dbConnection.Query<Customer>("Proc_CustomersPaging", param: parameters, commandType: CommandType.StoredProcedure);

                if (customerPagingData.Count() > 1)
                {
                    //4. Tra ve cho client
                    return StatusCode(200, customerPagingData);
                }
                else
                {
                    return NoContent();
                }

                //var response = StatusCode(200, parameters.Get<Int32>("@TotalPage"));
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Server_ErrorMsg,
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
                //Kiểm tra thông tin của khách hàng đã hợp lệ chưa
                //1. Mã khách hàng bắt buộc phải có
                if (customer.CustomerCode == "" || customer.CustomerCode == null)
                {
                    var errorObj = new
                    {
                        userMsg = "Mã khách hàng ko được phép để trống!",
                        errorCode = "misa-001",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }

                //2. Email phải đúng định dạng

                var emailFormat = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

                var isMatch = Regex.IsMatch(customer.Email, emailFormat, RegexOptions.IgnoreCase);

                if (isMatch == false)
                {
                    var errorObj = new
                    {
                        userMsg = "Emil không đúng định dạng!",
                        errorCode = "misa-001",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }

                //3. Mã không được trùng với mã của khách hàng khác

                //Khai bao dynamicParam:
                var dynamicParam = new DynamicParameters();


                ////3. Them du lieu vao db:
                //var columnsName = string.Empty;
                //var columnsParam = string.Empty;

                ////Doc tung prop cua obj:
                var properties = customer.GetType().GetProperties();

                ////Duyet tung prop:
                foreach (var prop in properties)
                {
                    //lay ten cua prop
                    var propName = prop.Name;

                    //lay val cu prop
                    var propValue = prop.GetValue(customer);

                    //lay du lieu cua prop
                    var propType = prop.PropertyType;

                    //Them param tuong ung voi moi prop
                    dynamicParam.Add($"@{propName}", propValue);

                    //columnsName += $"{propName},";
                    //columnsParam += $"@{propName},";
                }

                //columnsName = columnsName.Remove(columnsName.Length - 1, 1);
                //columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

                //var sqlCommand = $"INSERT INTO Customer({columnsName}) VALUE({columnsParam})";
                //Console.WriteLine(customer);
                var rowsEffect = dbConnection.Execute("Proc_InsertCustomer", param: dynamicParam, commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                if (rowsEffect > 0)
                {
                    return StatusCode(200, rowsEffect);

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
                    userMsg = Properties.Resources.Server_ErrorMsg,
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

                //Kiểm tra thông tin của khách hàng đã hợp lệ chưa
                //1. Mã khách hàng bắt buộc phải có
                if (customer.CustomerCode == "" || customer.CustomerCode == null)
                {
                    var errorObj = new
                    {
                        userMsg = "Mã khách hàng ko được phép để trống!",
                        errorCode = "misa-001",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }

                //2. Email phải đúng định dạng

                var emailFormat = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

                var isMatch = Regex.IsMatch(customer.Email, emailFormat, RegexOptions.IgnoreCase);

                if (isMatch == false)
                {
                    var errorObj = new
                    {
                        userMsg = "Emil không đúng định dạng!",
                        errorCode = "misa-001",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }

                var dynamicParam = new DynamicParameters();

                dynamicParam.Add("@CustomerId", customerId);

                ////3. Them du lieu vao db:
                //var columnsName = string.Empty;
                //var columnsParam = string.Empty;

                ////Doc tung prop cua obj:
                var properties = customer.GetType().GetProperties();

                ////Duyet tung prop:
                foreach (var prop in properties)
                {
                    //lay ten cua prop
                    var propName = prop.Name;

                    //lay val cu prop
                    var propValue = prop.GetValue(customer);

                    //lay du lieu cua prop
                    var propType = prop.PropertyType;

                    //Them param tuong ung voi moi prop
                    if (propValue != null && propName != "CustomerId")
                    {
                        dynamicParam.Add($"@{propName}", propValue);
                        //columnsName += $"{propName},";
                        //columnsParam += $"@{propName},";
                    }

                }

                //columnsName = columnsName.Remove(columnsName.Length - 1, 1);
                //columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

                //var sqlCommand = $"INSERT INTO Customer({columnsName}) VALUE({columnsParam})";
                //Console.WriteLine(customer);
                var rowsEffect = dbConnection.Execute("Proc_UpdateCustomer", param: dynamicParam, commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                if (rowsEffect > 0)
                {
                    return StatusCode(200, rowsEffect);
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
                    userMsg = Properties.Resources.Server_ErrorMsg,
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
                var rowsEffect = dbConnection.Execute("Proc_DeleteCustomer", param: parameters, commandType: CommandType.StoredProcedure);

                //4. Tra ve cho client
                if (rowsEffect > 0)
                {
                    return StatusCode(200, rowsEffect);
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
                    userMsg = Properties.Resources.Server_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }

        }
    }
}
