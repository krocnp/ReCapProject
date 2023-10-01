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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalsDal;

        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Rental rental)
        {
                _rentalsDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Rental rental)
        {
            _rentalsDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.RentalListed);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(r => r.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetail(),Messages.RentalListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Rental rental)
        {
            _rentalsDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
