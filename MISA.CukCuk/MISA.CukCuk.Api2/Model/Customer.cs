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
        /// Giới tính
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public int? Gnder { get; set; }

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

        #endregion
    }
}
