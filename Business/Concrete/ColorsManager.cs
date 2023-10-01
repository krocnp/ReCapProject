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
    public class ColorsManager : IColorsService
    {
        IColorsDal _colorsDal;

        public ColorsManager(IColorsDal colorsDal)
        {
            _colorsDal = colorsDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorsDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorsDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorsDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>( _colorsDal.GetAll(c => colorId == colorId).ToList());
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorsDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
