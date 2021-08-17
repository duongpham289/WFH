using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy danh sách thực thể
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin thực thể qua Id
        /// </summary>
        /// <param name="customerId">Mã định danh thực thể</param>
        /// <returns>Thông tin thực thể</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới thực thể
        /// </summary>
        /// <param name="customer">Thông tin thực thể</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Add(MISAEntity entity);

        /// <summary>
        /// Sửa thông tin thực thể
        /// </summary>
        /// <param name="customer">Thông tin thực thể</param>
        /// <param name="customerId">Mã định danh của thực thể</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa thực thể
        /// </summary>
        /// <param name="customer">Mã định danh của thực thể</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Delete(Guid entityId);
    }
}
