using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        #region Methods

        /// <summary>
        /// Lấy danh sách khách hàng phân trang
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi/trang</param>
        /// <param name="customerFilter">Dữ liệu lọc phân trang</param>
        /// <param name="customerGroupId">Mã định danh nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        Object GetPaging(int pageIndex, int pageSize, string customerFilter, Guid? customerGroupId);


        /// <summary>
        /// Thêm nhiều khách hàng dựa trên file nhập khẩu
        /// </summary>
        /// <param name="customers">Các khách hàng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(20/08/2021)
        int AddList(List<Customer> customers);
        #endregion
    }

}
