using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : ICustomerService
    {

        ICustomerRepository customerRepository;
        public ServiceResult Add(Customer customer)
        {
            //Xu ly nghiep vu:

            //Tuong tac ket noi voi DB:

            var rowEffects = customerRepository.Add(customer);
            throw new NotImplementedException();
        }

        public ServiceResult Update(Customer customer, Guid customerId)
        {
            //Xu ly nghiep vu:

            //Tuong tac ket noi voi DB:

            var rowEffects = customerRepository.Add(customer);
            throw new NotImplementedException();
        }
    }
}
