using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        #region Methods

        /// <summary>
        /// Lấy danh sách entity
        /// </summary>
        /// <returns>Danh sách entity</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin entity qua Id
        /// </summary>
        /// <param name="entityId">Mã định danh entity</param>
        /// <returns>Thông tin entity</returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới entity
        /// </summary>
        /// <param name="entity">Thông tin entity</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Add(MISAEntity entity);

        /// <summary>
        /// Sửa thông tin entity
        /// </summary>
        /// <param name="entity">Thông tin entity</param>
        /// <param name="entityId">Mã định danh của entity</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa entity
        /// </summary>
        /// <param name="entityId">Mã định danh của entity</param>
        /// CreatedBy: PHDUONG(13/08/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Xóa list entity
        /// </summary>
        /// <param name="listId">List mã định danh của entity</param>
        /// CreatedBy: PHDUONG(23/08/2021)
        int DeleteList(List<Guid> listId);

        /// <summary>
        /// Check trùng code
        /// </summary>
        /// <param name="entityCode">Mã thực thể</param>
        /// <param name="entityProperty">Thuộc tính thực thể</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(18/08/2021)
        bool IsDuplicated(string entityCode, string entityProperty);
        
        /// <summary>
        /// Check trùng code
        /// </summary>
        /// <param name="entityCode">Mã thực thể</param>
        /// <param name="entityProperty">Thuộc tính thực thể</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(18/08/2021)
        List<string> GetAllProp(string columnName);
        #endregion
    }
}
