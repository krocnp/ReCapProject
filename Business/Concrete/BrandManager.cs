using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandsDal;

        public BrandManager(IBrandDal brandsDal)
        {
            _brandsDal = brandsDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Brand brand)
        {
            _brandsDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Brand brand)
        {
            _brandsDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandsDal.GetAll(),Messages.BrandListed);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandsDal.GetAll(b => b.BrandId == brandId).ToList());
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Brand brand)
        {
            _brandsDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
