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

        [HttpPost]
        public List<Customer> InsertCustomers([FromBody] List<Customer> customers)
        {
            //var name = customers[0].FullName;
            return customers;
        }
    }
}
