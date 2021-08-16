using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        List<Customer> GetAll();

        /// <summary>
        /// Lấy thông tin khách hàng qua Id
        /// </summary>
        /// <param name="customerId">Mã định danh khách hàng</param>
        /// <returns>Thông tin khách hàng</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        Customer GetById(Guid customerId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Add(Customer customer);

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <param name="customerId">Mã định danh của khách hàng</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Update(Customer customer, Guid customerId);

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customer">Mã định danh của khách hàng</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Delete(Guid customerId);
    }
}
