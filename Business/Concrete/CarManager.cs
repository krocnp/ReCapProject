using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carsDal;

        public CarManager(ICarDal carsDal)
        {
            _carsDal = carsDal;
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Car car)
        {
            _carsDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Car car)
        {
            _carsDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(), Messages.CarsListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.CarId == id).ToList());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(p => p.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(p => p.ColorId == colorId).ToList());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails(), Messages.CarsListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Car car)
        {
            _carsDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
