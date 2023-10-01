using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class CarsManager : ICarsService
    {
        ICarsDal _carsDal;

        public CarsManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carsDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carsDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(), Messages.CarsListed);
        }

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

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails(), Messages.CarsListed);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carsDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
