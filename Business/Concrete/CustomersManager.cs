using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService 
    {
        ICustomersDal _customersDal;

        public CustomersManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customersDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customersDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(c => c.UserId == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customersDal.GetCustomer(),Messages.CustomerListed);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customersDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
