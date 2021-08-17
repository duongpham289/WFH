using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        protected ServiceResult _serviceResult;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(16/08/2021)
        public ServiceResult Add(MISAEntity entity)
        {
            //2. Validate du lieu va xu ly nghiep vu:
            if (!ValidateCustom(entity))
            {
                return _serviceResult;
            }

            //thuc hien them moi:
            _serviceResult.Data = _baseRepository.Add(entity);

            return _serviceResult;

        }

        /// <summary>
        /// Sửa dữ liệu trong DataBase
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(16/08/2021)
        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            //validate du lieu va xu ly nghiep vu:

            //thuc hien them moi:
            _serviceResult.Data = _baseRepository.Update(entity, entityId);

            return _serviceResult;
        }

        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            var isValid = true;

            return isValid;
        }
    }
}
