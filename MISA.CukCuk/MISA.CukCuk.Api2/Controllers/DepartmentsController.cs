using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntityController<Department>
    {
        #region DECLARE

        //ICustomerRepository _customerRepository;
        IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DepartmentsController(IDepartmentService departmentService, IBaseRepository<Department> baseRepository) : base(departmentService, baseRepository)
        {
            //_customerRepository = customerRepository;
            _departmentService = departmentService;
        }
        #endregion
    }
}
