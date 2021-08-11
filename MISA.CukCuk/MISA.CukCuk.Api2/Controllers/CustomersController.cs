using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Api.Model;
using System.Data;
using MySqlConnector;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IDbConnection dbConnection;

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
            //3. Lay du lieu:
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);

            //4. Tra ve cho client
            var response = StatusCode(200, customers);
            return response;
        }

        /// <summary>
        /// Lấy thông tin Khách hàng theo Id
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns>Thông tin Khách hàng dạng Json</returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {

            //3. Lay du lieu:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", param: parameters, commandType: CommandType.StoredProcedure);

            //4. Tra ve cho client
            var response = StatusCode(200, customer);
            return response;
        }

        /// <summary>
        /// Thêm Khách Hàng vào cơ sở dữ liệu
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
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
            var rowEfects = dbConnection.Execute("Proc_InsertCustomer", param: dynamicParam, commandType: CommandType.StoredProcedure);

            //4. Tra ve cho client
            var response = StatusCode(200, rowEfects);
            return response;
        }

        /// <summary>
        /// Sửa Khách Hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(Customer customer, Guid customerId)
        {

            //2. Khoi tao doi tuong ket noi voi db
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection"));
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
                if (propValue != null && propName != "CustomerId")
                {
                    dynamicParam.Add($"@{propName}", propValue);
                    //columnsName += $"{propName},";
                    //columnsParam += $"@{propName},";
                }

            }

            dynamicParam.Add("@CustomerId", customerId);

            //columnsName = columnsName.Remove(columnsName.Length - 1, 1);
            //columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

            //var sqlCommand = $"INSERT INTO Customer({columnsName}) VALUE({columnsParam})";
            //Console.WriteLine(customer);
            var rowEfects = dbConnection.Execute("Proc_UpdateCustomer", param: dynamicParam, commandType: CommandType.StoredProcedure);

            //4. Tra ve cho client
            var response = StatusCode(200, rowEfects);
            return response;
        }


        /// <summary>
        /// Xóa Khách hàng 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {

            //2. Khoi tao doi tuong ket noi voi db
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection"));

            //3. Lay du lieu:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var rowEfects = dbConnection.Execute("Proc_DeleteCustomer", param: parameters, commandType: CommandType.StoredProcedure);

            //4. Tra ve cho client
            var response = StatusCode(200, rowEfects);
            return response;
        }
    }
}
