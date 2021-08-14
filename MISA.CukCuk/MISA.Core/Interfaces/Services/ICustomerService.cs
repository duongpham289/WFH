using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>ServiceResult - kết quả xử lý qua nghiệp vụ</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        ServiceResult Add(Customer customer);

        // <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>ServiceResult - kết quả xử lý qua nghiệp vụ</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        ServiceResult Update(Customer customer, Guid customerId);
    }
}
