using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        #region Methods
        /// <summary>
        /// Lấy dữ liệu Mã entity
        /// </summary>
        /// <param name="columnName">Tên cột</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(16/08/2021)
        ServiceResult GetNewCode(string columnName);

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(16/08/2021)
        ServiceResult Add(MISAEntity entity);

        /// <summary>
        /// Sửa dữ liệu trong DataBase
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(16/08/2021)
        ServiceResult Update(MISAEntity entity, Guid entityId);
        #endregion
    }
}
