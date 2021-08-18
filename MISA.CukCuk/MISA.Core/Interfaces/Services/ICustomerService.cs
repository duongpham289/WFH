using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        #region Methods

        /// <summary>
        /// Xử lí dữ liệu khách hàng phân trang
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi/trang</param>
        /// <param name="customerFilter">Dữ liệu lọc phân trang</param>
        /// <param name="customerGroupId">Mã định danh nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        ServiceResult GetPaging(int pageIndex, int pageSize, string customerFilter, Guid? customerGroupId);
        #endregion
    }
}
