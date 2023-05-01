using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carsDal.Add(car);
            }
            else
            {
                throw new Exception("Gerekli şartlar sağlanmıyor");
            }
        }

        public List<Car> GetAll()
        {
            return _carsDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carsDal.GetAll(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carsDal.GetAll(p => p.ColorId == colorId).ToList();
        }
    }
}
