﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructor
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy danh sách khách hàng phân trang từ DataBase
        /// </summary>
        /// <returns>Danh sách khách hàng và dữ liệu phân trang</returns>
        /// CreatedBy: PHDUONG(17/08/2021)
        public Object GetPaging(int pageIndex, int pageSize, string customerFilter, Guid? customerGroupId)
        {
            using (_dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerFilter", customerFilter != null ? customerFilter : String.Empty);
                parameters.Add("@CustomerGroupId", customerGroupId);
                parameters.Add("@PageIndex", pageIndex);
                parameters.Add("@PageSize", pageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var data = _dbConnection.Query<Customer>($"Proc_GetCustomerFilterPaging", param: parameters, commandType: CommandType.StoredProcedure);

                var totalPage = parameters.Get<Int32>("@TotalPage");
                var totalRecord = parameters.Get<Int32>("@TotalRecord");


                var pagingData = new
                {
                    totalPage,
                    totalRecord,
                    data
                };

                return pagingData;
            }
        }
        #endregion


    }
}