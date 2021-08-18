﻿using System;
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
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
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
