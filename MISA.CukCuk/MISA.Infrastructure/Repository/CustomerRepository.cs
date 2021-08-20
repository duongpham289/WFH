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


        /// <summary>
        /// Thêm nhiều khách hàng  
        /// </summary>
        /// <param name="customers">List các khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(20/08/2021)
        public int AddList(List<Customer> customers)
        {
            using (_dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                _dbConnection.Open();
                var transaction = _dbConnection.BeginTransaction();

                var rowsEffect = 0;
                foreach (var customer in customers)
                {

                    var dynamicParam = new DynamicParameters();

                    ////3. Them du lieu vao db:

                    ////Doc tung prop cua obj:
                    var properties = customer.GetType().GetProperties();

                    ////Duyet tung prop:
                    foreach (var prop in properties)
                    {
                        //lay ten cua prop
                        var propName = prop.Name;

                        //lay val cu prop
                        var propValue = prop.GetValue(customer);

                        //Them param tuong ung voi moi prop
                        dynamicParam.Add($"@{propName}", propValue);
                    }

                    rowsEffect += _dbConnection.Execute($"Proc_InsertCustomer", param: dynamicParam, transaction: transaction, commandType: CommandType.StoredProcedure);
                }

                transaction.Commit();

                return rowsEffect;
            }
        }
        #endregion


    }
}
