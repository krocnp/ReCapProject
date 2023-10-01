using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helplers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImages, IFileHelper fileHelper)
        {
            _carImagesDal = carImages;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagesPath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagesPath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            carImage.ImagesPath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagesPath, PathConstants.ImagesPath);
            _carImagesDal.Update(carImage);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {
            List<CarImages> carImages = new List<CarImages>();
            carImages.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagesPath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImages);
        }

        private IResult CheckCarImage(int carId) 
        { 
            var result = _carImagesDal.GetAll(c=>c.CarId == carId).Count;
            if(result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
