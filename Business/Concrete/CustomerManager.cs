using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
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
    public class CustomerManager : ICustomerService 
    {
        ICustomerDal _customersDal;

        public CustomerManager(ICustomerDal customersDal)
        {
            _customersDal = customersDal;
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Customer customer)
        {
            _customersDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Customer customer)
        {
            _customersDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(),Messages.CustomerListed);
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(c => c.UserId == id));
        }
        [CacheAspect]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customersDal.GetCustomer(),Messages.CustomerListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Customer customer)
        {
            _customersDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
