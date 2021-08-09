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

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET, POST, PUT, DELETE

        [HttpGet]
        public IActionResult GetCustomers()
        {

            //Truy cap vào db:
            //1. Khai bao thong tin ket noi db:
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MF960_PHDUONG_CukCuk;" +
                "User Id = dev;" +
                "Password = 12345678;";

            //2. Khoi tao doi tuong ket noi voi db
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            //3. Lay du lieu:
            var sqlCommand = "SELECT * FROM Customer";
            var customers = dbConnection.Query<object>(sqlCommand);

            //4. Tra ve cho client
            var response = StatusCode(200, customers);
            return response;
        }


        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            //Truy cap vào db:
            //1. Khai bao thong tin ket noi db:
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MF960_PHDUONG_CukCuk;" +
                "User Id = dev;" +
                "Password = 12345678;";

            //2. Khoi tao doi tuong ket noi voi db
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            //3. Lay du lieu:
            var sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = @CustomerIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerIdParam", customerId);
            var customer = dbConnection.QueryFirstOrDefault<object>(sqlCommand,param:parameters);

            //4. Tra ve cho client
            var response = StatusCode(200, customer);
            return response;
        }

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            //Truy cap vào db:
            //1. Khai bao thong tin ket noi db:
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MF960_PHDUONG_CukCuk;" +
                "User Id = dev;" +
                "Password = 12345678;";

            //2. Khoi tao doi tuong ket noi voi db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Khai bao dynamicParam:
            var dynamicParam = new DynamicParameters();


            //3. Them du lieu vao db:
            var columnsName = string.Empty;
            var columnsParam = string.Empty;

            //Doc tung prop cua obj:
            var properties = customer.GetType().GetProperties();

            //Duyet tung prop:
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

                columnsName += $"{propName},";
                columnsParam += $"@{propName},";
            }

            columnsName = columnsName.Remove(columnsName.Length - 1, 1);
            columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

            var sqlCommand = $"INSERT INTO Customer({columnsName}) VALUE({columnsParam})";

            var rowEfects = dbConnection.Execute(sqlCommand, param:dynamicParam);

            //4. Tra ve cho client
            var response = StatusCode(200, rowEfects);
            return response;
        }
    }
}
