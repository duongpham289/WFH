using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class CustomerGroup : BaseEntity
    {
        #region BaseProperty
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy:PHDUONG(07/08/2021)
        public string Description { get; set; }

        #endregion

    }
}
