using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandsManager : IBrandsService
    {
        IBrandsDal _brandsDal;

        public BrandsManager(IBrandsDal brandsDal)
        {
            _brandsDal = brandsDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandsDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandsDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandsDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandsDal.GetAll(b => b.BrandId == brandId).ToList());
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandsDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
