using MISA.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid EmployeeId { get; set; }

        [MISARequired("Mã nhân viên")]
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ vầ tên đệm
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string LastName { get; set; }

        [MISARequired("Họ và tên")]
        /// <summary>
        /// Họ và tên
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính (0 - Nữ, 1 - Nam, 2 - Khác)
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public int? Gender { get; set; }

        /// <summary>
        /// Giới tính 
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string GenderName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public DateTime? DateOfBirth { get; set; }

        [MISARequired("Số điện thoại")]
        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số Căn cước công dân
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp Căn cước công dân
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp Căn cước công dân
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân (0 - Chưa kết hôn, 1 - Đã kết hôn)
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public int? MartialStatus { get; set; }

        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public int? EducationalBackground { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid? QualificationId { get; set; }

        /// <summary>
        /// Khóa ngoại

        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string DepartmentName { get; set; }

        /// <summary>
        /// Khóa ngoại 
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string PositionName { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public double? Salary { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string PersonalTaxCode { get; set; }
    }
}
