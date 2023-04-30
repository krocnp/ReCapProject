using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarsManager carsManager = new CarsManager(new InMemoryCarsDal());
        BrandsManager brandsManager = new BrandsManager(new InMemoryBrandsDal());
        ColorsManager colorsManager = new ColorsManager(new InMemoryColorsDal());


        foreach (var car in carsManager.GetAll())
        {

            foreach (var brand in brandsManager.GetById(car.BrandId))
            {
                foreach (var color in colorsManager.GetById(car.ColorId))
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, brand.BrandName, color.ColorName, car.ModelYear, car.DailyPrice, car.Description);
                }
            }
        
            
        }

        Console.Read();
    }
}