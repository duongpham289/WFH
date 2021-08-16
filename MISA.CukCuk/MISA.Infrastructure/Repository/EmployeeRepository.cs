using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection dbConnection;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
        public List<Employee> GetAll()
        {
            var employees = dbConnection.Query<Employee>("Proc_GetEmployees", commandType: CommandType.StoredProcedure);

            return employees.AsList();
        }

        public int Add(Employee employee)
        {
            throw new NotImplementedException();
        }


        public int Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
