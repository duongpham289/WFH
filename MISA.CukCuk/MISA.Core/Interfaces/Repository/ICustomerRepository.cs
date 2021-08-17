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

        /// <summary>
        /// Lấy thông tin thực thể qua Id
        /// </summary>
        /// <param name="customerId">Mã định danh thực thể</param>
        /// <returns>Thông tin thực thể</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        Object GetPaging(int pageIndex, int PageSize);
    }


}
