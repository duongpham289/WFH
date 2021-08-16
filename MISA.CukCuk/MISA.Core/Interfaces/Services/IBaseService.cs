using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        ServiceResult Add(MISAEntity entity);
        ServiceResult Update(MISAEntity entity, Guid entityId);
    }
}
