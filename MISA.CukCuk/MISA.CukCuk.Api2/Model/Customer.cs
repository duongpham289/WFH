using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    public class Customer : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string CustomerCode { get; set; }

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
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số tiền còn nợ
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Double? DebitAmount { get; set; }

        /// <summary>
        /// Mã thẻ Thành viên
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Tên Công ty
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của Công ty
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Ngừng theo dõi (true - Ngừng theo dõi)
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public bool? IsStopFollow { get; set; }

        /// <summary>
        /// Khóa chính
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        #endregion
    }
}
