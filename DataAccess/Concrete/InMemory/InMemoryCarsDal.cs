using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarsDal : ICarsDal
    {
        List<Car> _cars;

        public InMemoryCarsDal()
        {
            _cars = new List<Car>{
                new Car { CarId=1, BrandId=1,ColorId=1,ModelYear=2022,DailyPrice=300,Description="Deneme1"},
                new Car { CarId=2, BrandId=1,ColorId=2,ModelYear=2022,DailyPrice=275,Description="Deneme2"},
                new Car { CarId=3, BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=350,Description="Deneme3"},
                new Car { CarId=4, BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=325,Description="Deneme4"},
                new Car { CarId=5, BrandId=3,ColorId=3,ModelYear=2023,DailyPrice=250,Description="Deneme5"}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car cars)
        {
            _cars.Add(cars);
        }

        public void Delete(Car cars)
        {
            _cars.Remove(_cars.SingleOrDefault(p => p.CarId == cars.CarId));
        }

        public List<Car> GetById(int carsId)
        {
            return _cars.Where(p => p.CarId == carsId).ToList();
        }

        public void Update(Car cars)
        {
            Car carsToUpdate = _cars.SingleOrDefault(p => p.CarId == cars.CarId);
            carsToUpdate.BrandId = cars.BrandId;
            carsToUpdate.ColorId = cars.ColorId;
            carsToUpdate.ModelYear = cars.ModelYear;
            carsToUpdate.DailyPrice = cars.DailyPrice;
            carsToUpdate.Description = cars.Description;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
