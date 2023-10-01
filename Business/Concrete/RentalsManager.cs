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
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
                _rentalsDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalsDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetail(),Messages.RentalListed);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalsDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
