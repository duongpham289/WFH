using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        List<Employee> GetAll();

        /// <summary>
        /// Lấy thông tin nhân viên qua Id
        /// </summary>
        /// <param name="employeeId">Mã định danh nhân viên</param>
        /// <returns>Thông tin nhân viên</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        Customer GetById(Guid employeeId);

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Add(Employee employee);

        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <param name="employeeId">Mã định danh của nhân viên</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Update(Employee employee, Guid employeeId);

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Mã định danh của nhân viên</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Delete(Guid employeeId);
    }
}
