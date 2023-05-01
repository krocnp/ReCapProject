using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        CarsManager carsManager = new CarsManager(new EfCarDal());

        carsManager.Add(new Car
        {
            BrandId = 3,
            ColorId = 1,
            ModelYear = 2023,
            DailyPrice = 400,
            Description = "Testing6"
        });


        foreach (var car in carsManager.GetAll())
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId,car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);


        }

    }
}