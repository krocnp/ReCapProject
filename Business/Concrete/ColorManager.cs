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
    public class ColorManager : IColorService
    {
        IColorDal _colorsDal;

        public ColorManager(IColorDal colorsDal)
        {
            _colorsDal = colorsDal;
        }
        [SecuredOperation("admin")]//Yetki kontrolü yapılıyor
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]//Add methodu çalıştırılmadan önce get içeren cacheler siliniyor
        [PerformanceAspect(5)]
        public IResult Add(Color color)
        {
            _colorsDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Color color)
        {
            _colorsDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorsDal.GetAll(),Messages.ColorListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]//işlem süresi 5 saniyeyi geçerse beni uyar
        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>( _colorsDal.GetAll(c => colorId == colorId).ToList());
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Color color)
        {
            _colorsDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
