using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region DECLARE
        ICustomerRepository _customerRepository;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository, IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Xử lí dữ liệu khách hàng phân trang
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi/trang</param>
        /// <param name="customerFilter">Dữ liệu lọc phân trang</param>
        /// <param name="customerGroupId">Mã định danh nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(13/08/2021)
        public ServiceResult GetPaging(int pageIndex, int pageSize, string customerFilter, Guid? customerGroupId)
        {
            _serviceResult.Data = _customerRepository.GetPaging(pageIndex, pageSize, customerFilter, customerGroupId);

            return _serviceResult;
        }
        #endregion



        #region ValidateMethods

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="customer">Dữ liệu cần validate</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(17/08/2021)
        protected override bool ValidateCustom(Customer customer)
        {
            //Kiểm tra thông tin của khách hàng đã hợp lệ chưa
            //1.Mã khách hàng bắt buộc phải có
            if (customer.CustomerCode == "" || customer.CustomerCode == null)
            {
                var errorObj = new
                {
                    userMsg = Resources.ResourceVN.CustomerCodeValidateError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult.IsValid;
            }

            //2. Email phải đúng định dạng

            var emailFormat = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            var isMatch = Regex.IsMatch(customer.Email, emailFormat, RegexOptions.IgnoreCase);

            if (isMatch == false)
            {
                var errorObj = new
                {
                    userMsg = Resources.ResourceVN.EmailValidateError_Msg,
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult.IsValid;
            }

            return _serviceResult.IsValid;

        }
        #endregion

    }
}
