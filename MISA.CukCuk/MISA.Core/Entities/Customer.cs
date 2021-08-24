using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Customer : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string CustomerCode { get; set; }

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
        /// Địa chỉ
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số tiền còn nợ
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Double? DebitAmount { get; set; }

        /// <summary>
        /// Mã thẻ Thành viên
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Tên Công ty
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của Công ty
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Ngừng theo dõi (true - Ngừng theo dõi)
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public bool? IsStopFollow { get; set; }

        /// <summary>
        /// Khóa ngoại 
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Lỗi nhập khẩu
        /// </summary>
        /// CreatedBy:PHDUONG(21/08/2021)
        public List<string> ImportError { get; set; } = new List<string>();

        /// <summary>
        /// Bản ghi hợp lệ 
        /// </summary>
        /// CreatedBy:PHDUONG(21/08/2021)
        public bool IsValid { get; set; } = true;

        #endregion

    }
}
