﻿using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Text.RegularExpressions;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        //IEmployeeRepository _employeeRepository;

        public EmployeeService(IBaseRepository<Employee> baseRepository):base(baseRepository)
        {
            //_employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="customer">Dữ liệu cần validate</param>
        /// <returns></returns>
        /// CreatedBy: PHDUONG(17/08/2021)
        protected override bool ValidateCustom(Employee employee)
        {
            //Kiểm tra thông tin của nhân viên đã hợp lệ chưa
            //1.Mã nhân viên bắt buộc phải có
            if (employee.EmployeeCode == "" || employee.EmployeeCode == null)
            {
                var errorObj = new
                {
                    userMsg = Resources.ResourceVN.EmployeeCodeValidateError_Msg,
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

            var isMatch = Regex.IsMatch(employee.Email, emailFormat, RegexOptions.IgnoreCase);

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
    }
}
