using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Position : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã Vị trí
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public string Description { get; set; }
    }
}
