using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        //ServiceResult AddEmployee(Employee employee);
        //ServiceResult UpdateEmployee(Employee employee, Guid employeeId);
    }
}
