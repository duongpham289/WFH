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
        /// Ngày Tạo
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// Author:PHDUONG(07/08/2021)
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion

    }
}
