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



        /// <summary>
        /// Lấy danh sách Thực thể từ DataBase
        /// </summary>
        /// <returns>List Thực thể</returns>
        /// CreatedBy: PHDUONG(17/08/2021)
        public Object GetPaging(int pageIndex, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var data = dbConnection.Query<Customer>($"Proc_GetCustomersPaging", param: parameters, commandType: CommandType.StoredProcedure);
            var dataCount = data.AsList().Count;

            var totalPage = parameters.Get<Int32>("@TotalPage");
            var totalRecord = parameters.Get<Int32>("@TotalRecord");


            var pagingData = new
            {
                totalPage,
                totalRecord,
                dataCount,
                data
            };

            return pagingData;
        }
    }
}
