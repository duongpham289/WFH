using Microsoft.AspNetCore.Http;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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


        /// <summary>
        /// Xử lý Validate dữ liệu nhập khẩu
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// CreatedDBy: PHDUONG(20/08/2021)
        public ServiceResult ImportCustomer(IFormFile formFile, CancellationToken cancellationToken)
        {
            var customers = new List<Customer>();
            if (formFile == null)
            {
                var errorObj = new
                {
                    devMsg = "null file",
                    userMsg = "Vui lòng chọn tệp nhập khẩu",
                };
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            //Check file co hop le khong (file cos dinh dang xls hoac xlsx)

            //Check do lon cua file (gioi han 100M)

            //Thuc hien doc du lieu tep excel
            using (var stream = new MemoryStream())
            {
                formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    //Tạo 2 mảng chứa tất cả customerCode và phoneNumber
                    var customerCodesInFile = new List<string>();
                    //var customerCodesInServer = new List<string>();
                    var customerPhoneNumbersInFile = new List<string>();

                    //Duyệt tất cả sheet, add customerCode và phoneNumber vào 2 mảng customerCodes và customerPhoneNumbers
                    for (int row = 3; row <= rowCount; row++)
                    {
                        var customerCode = worksheet.Cells[row, 1].Value;
                        var customerPhoneNumber = worksheet.Cells[row, 5].Value;


                        if (customerCode != null)
                        {
                            customerCodesInFile.Add(customerCode.ToString());
                        };

                        if (customerPhoneNumber != null)
                        {
                            customerPhoneNumbersInFile.Add(customerPhoneNumber.ToString());
                        };
                    }

                    //Duyệt tất cả sheet, validate dữ liệu từng dòng
                    for (int row = 3; row <= rowCount; row++)
                    {
                        var customer = new Customer();
                        for (int index = 1; index <= 10; index++)
                        {
                            var item = worksheet.Cells[row, index].Value;

                            if (item != null)
                            {
                                //Validate từng cột của mỗi dòng
                                switch (index)
                                {

                                    case 1:
                                        if (customerCodesInFile.IndexOf(item.ToString()) != -1)
                                        {
                                            var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportDuplicateInFileError_Msg;
                                            customer.ImportError.Add(msgError);
                                        }
                                        if (_customerRepository.IsDuplicated(item.ToString(), string.Empty))
                                        {
                                            var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportDuplicateInServerError_Msg;
                                            customer.ImportError.Add(msgError);
                                        }
                                        customer.CustomerCode = item.ToString();
                                        break;
                                    case 2:
                                        customer.FullName = item.ToString();
                                        break;
                                    case 3:
                                        customer.MemberCardCode = item.ToString();
                                        break;
                                    case 4:
                                        // Check Nhóm khách hàng tồn tại
                                        if (!_customerRepository.IsDuplicated(string.Empty, item.ToString()))
                                        {
                                            var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportNotFoundInServerError_Msg;
                                            customer.ImportError.Add(msgError);
                                        }
                                        customer.CustomerGroupName = item.ToString();
                                        break;
                                    case 5:
                                        // Check trùng số điện thoại
                                        if (customerPhoneNumbersInFile.IndexOf(item.ToString()) != -1)
                                        {
                                            var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportDuplicateInFileError_Msg;
                                            customer.ImportError.Add(msgError);
                                        }
                                        if (_customerRepository.IsDuplicated(string.Empty, item.ToString()))
                                        {
                                            var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportDuplicateInServerError_Msg;
                                            customer.ImportError.Add(msgError);
                                        }
                                        customer.PhoneNumber = item.ToString();
                                        break;
                                    case 6:
                                        if (Regex.IsMatch(item.ToString().Trim(), @"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"))
                                        {
                                            customer.DateOfBirth = DateTime.ParseExact(item.ToString().Trim(), "dd/MM/yyyy", null);
                                        }
                                        if (Regex.IsMatch(item.ToString().Trim(), @"^(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"))
                                        {
                                            customer.DateOfBirth = DateTime.ParseExact("01/" + item.ToString().Trim(), "dd/MM/yyyy", null);
                                        }
                                        if (Regex.IsMatch(item.ToString().Trim(), @"^\d{4}$"))
                                        {
                                            customer.DateOfBirth = DateTime.ParseExact("01/01/" + item.ToString().Trim(), "dd/MM/yyyy", null);
                                        }
                                        break;
                                    case 7:
                                        customer.CompanyName = item.ToString();
                                        break;
                                    case 8:
                                        customer.CompanyTaxCode = item.ToString();
                                        break;
                                    case 9:
                                        customer.Email = item.ToString();
                                        break;
                                    case 10:
                                        customer.Address = item.ToString();
                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                if (index == 1 || index == 2)
                                {
                                    var msgError = worksheet.Cells[2, index].Value.ToString().Replace("(*)", "").Trim() + Resources.ResourceVN.CustomerImportEmptyError_Msg;
                                    customer.ImportError.Add(msgError);
                                }

                            }
                        }

                        customers.Add(customer);
                    }
                }
            }
                //_serviceResult.Data = _customerRepository.AddList(customers);
                _serviceResult.Data = customers;

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
