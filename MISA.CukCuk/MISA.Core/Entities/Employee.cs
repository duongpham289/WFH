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
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid EmployeeId { get; set; }

        [MISARequired("Mã nhân viên")]
        /// <summary>
        /// Mã khách hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ vầ tên đệm
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string LastName { get; set; }

        [MISARequired("Họ và tên")]
        /// <summary>
        /// Họ và tên
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính (0 - Nữ, 1 - Nam, 2 - Khác)
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Giới tính 
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string GenderName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        [MISARequired("Số điện thoại")]
        /// <summary>
        /// Số điện thoại
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số Căn cước công dân
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp Căn cước công dân
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp Căn cước công dân
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân (0 - Chưa kết hôn, 1 - Đã kết hôn)
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public int? MartialStatus { get; set; }

        /// <summary>
        /// Trình độ học vấn
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public int? EducationalBackground { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid? QualificationId { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Khóa ngoại 
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string PersonalTaxCode { get; set; }
    }
}
