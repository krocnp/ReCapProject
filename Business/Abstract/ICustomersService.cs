using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetById(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
