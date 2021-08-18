﻿using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region DECLARE

        IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository, IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}
