using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region Methods

        /// <summary>
        /// Lấy danh sách nhân viên phân trang
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi/trang</param>
        /// <param name="employeeFilter">Dữ liệu lọc phân trang</param>
        /// <param name="departmentId">Mã định danh Phòng ban</param>
        /// <param name="positionId">Mã định danh Vị trí</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        Object GetPaging(int pageIndex, int pageSize, string employeeFilter, Guid? departmentId, Guid? positionId);

        #endregion
    }
}
