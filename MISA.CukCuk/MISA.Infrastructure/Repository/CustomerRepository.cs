using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }

        public Customer GetById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
