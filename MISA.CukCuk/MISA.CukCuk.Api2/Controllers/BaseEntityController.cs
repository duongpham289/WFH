using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy danh sách Khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng dạng Json</returns>
        /// CreatedBy: PHDUONG(07/08/2021)
        [HttpGet]
        public virtual IActionResult Get()
        {

            try
            {
                var entities = _baseRepository.GetAll();

                //4. Trả dữ liệu cho client
                if (entities.Count > 0)
                {
                    return StatusCode(200, entities);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""

                };
                return StatusCode(500, errorObj);
            }

        }

        /// <summary>
        /// Lấy thông tin Khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns>Thông tin Khách hàng dạng Json</returns>
        /// CreatedBy: PHDUONG(07/08/2021)
        [HttpGet("{customerId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            try
            {

                //3. Lay du lieu:
                var entity = _baseRepository.GetById(entityId);

                //4.tra ve cho client
                if (entity != null)
                {
                    return StatusCode(200, entity);

                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
        }

        /// <summary>
        /// Thêm Khách Hàng vào cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(07/08/2021)
        [HttpPost]
        public virtual IActionResult Insert(MISAEntity entity)
        {
            try
            {
                var serviceReSult = _baseService.Add(entity);

                //4. Trả dữ liệu cho client
                if (serviceReSult.IsValid == true)
                {
                    return StatusCode(201, serviceReSult.Data);

                }
                else
                {
                    return BadRequest(serviceReSult.Data);
                }
            }
            catch (Exception ex)
            {

                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }


        }

        /// <summary>
        /// Sửa Khách Hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(07/08/2021)
        [HttpPut("{customerId}")]
        public virtual IActionResult Update(MISAEntity entity, Guid entityId)
        {
            try
            {
                var serviceReSult = _baseService.Update(entity, entityId);

                //4. Tra ve cho client
                if (serviceReSult.IsValid == true)
                {
                    return StatusCode(200, serviceReSult.Data);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }



        }


        /// <summary>
        /// Xóa Khách hàng 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(07/08/2021)
        [HttpDelete("{customerId}")]
        public virtual IActionResult Delete(Guid entityId)
        {
            try
            {

                //3. Lay du lieu:
                var rowsEffect = _baseRepository.Delete(entityId);

                //4. Tra ve cho client
                if (rowsEffect > 0)
                {
                    return StatusCode(200, rowsEffect);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Core.Resources.ResourceVN.ExceptionError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }

        }
        #endregion
    }
}
