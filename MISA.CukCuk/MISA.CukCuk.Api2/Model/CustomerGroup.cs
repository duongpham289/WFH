using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    public class CustomerGroup : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên Group
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
