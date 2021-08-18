using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Qualification
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public Guid QualificationId { get; set; }

        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public string QualificationName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBY: PHDUONG(18/08/2021)
        public string Description { get; set; }
    }
}
